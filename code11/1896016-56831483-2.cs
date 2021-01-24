    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.EntityFrameworkCore.Query.Expressions;
    using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
    using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
    using Microsoft.EntityFrameworkCore.Query.Internal;
    using Remotion.Linq;
    using Remotion.Linq.Clauses;
    using Remotion.Linq.Clauses.ResultOperators;
    using Remotion.Linq.Clauses.StreamedData;
    using Remotion.Linq.Parsing.Structure.IntermediateModel;
    
    namespace Microsoft.EntityFrameworkCore
    {
    	public static partial class CustomExtensions
    	{
    		public static int CountDistinct<T, TKey>(this IQueryable<T> source, Expression<Func<T, TKey>> keySelector)
    			=> source.Select(keySelector).Distinct().Count();
    
    		public static int CountDistinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
    			=> source.Select(keySelector).Distinct().Count();
    
    		public static DbContextOptionsBuilder UseCustomExtensions(this DbContextOptionsBuilder optionsBuilder)
    			=> optionsBuilder
    				.ReplaceService<INodeTypeProviderFactory, CustomNodeTypeProviderFactory>()
    				.ReplaceService<IRelationalResultOperatorHandler, CustomRelationalResultOperatorHandler>();
    	}
    }
    
    namespace Remotion.Linq.Parsing.Structure.IntermediateModel
    {
    	public sealed class CountDistinctExpressionNode : ResultOperatorExpressionNodeBase
    	{
    		public CountDistinctExpressionNode(MethodCallExpressionParseInfo parseInfo, LambdaExpression optionalSelector)
    			: base(parseInfo, null, optionalSelector) { }
    		public static IEnumerable<MethodInfo> GetSupportedMethods()
    			=> typeof(CustomExtensions).GetTypeInfo().GetDeclaredMethods("CountDistinct");
    		public override Expression Resolve(ParameterExpression inputParameter, Expression expressionToBeResolved, ClauseGenerationContext clauseGenerationContext)
    			=> throw CreateResolveNotSupportedException();
    		protected override ResultOperatorBase CreateResultOperator(ClauseGenerationContext clauseGenerationContext)
    			=> new CountDistinctResultOperator();
    	}
    }
    
    namespace Remotion.Linq.Clauses.ResultOperators
    {
    	public sealed class CountDistinctResultOperator : ValueFromSequenceResultOperatorBase
    	{
    		public override ResultOperatorBase Clone(CloneContext cloneContext) => new CountDistinctResultOperator();
    		public override StreamedValue ExecuteInMemory<T>(StreamedSequence input) => throw new NotSupportedException();
    		public override IStreamedDataInfo GetOutputDataInfo(IStreamedDataInfo inputInfo) => new StreamedScalarValueInfo(typeof(int));
    		public override string ToString() => "CountDistinct()";
    		public override void TransformExpressions(Func<Expression, Expression> transformation) { }
    	}
    }
    
    namespace Microsoft.EntityFrameworkCore.Query.Internal
    {
    	public class CustomNodeTypeProviderFactory : DefaultMethodInfoBasedNodeTypeRegistryFactory
    	{
    		public CustomNodeTypeProviderFactory()
    			=> RegisterMethods(CountDistinctExpressionNode.GetSupportedMethods(), typeof(CountDistinctExpressionNode));
    	}
    
    	public class CustomRelationalResultOperatorHandler : RelationalResultOperatorHandler
    	{
    		private static readonly ISet<Type> AggregateResultOperators = (ISet<Type>)
    			typeof(RequiresMaterializationExpressionVisitor).GetField("_aggregateResultOperators", BindingFlags.NonPublic | BindingFlags.Static)
    			.GetValue(null);
    
    		static CustomRelationalResultOperatorHandler()
    			=> AggregateResultOperators.Add(typeof(CountDistinctResultOperator));
    
    		public CustomRelationalResultOperatorHandler(IModel model, ISqlTranslatingExpressionVisitorFactory sqlTranslatingExpressionVisitorFactory, ISelectExpressionFactory selectExpressionFactory, IResultOperatorHandler resultOperatorHandler)
    			: base(model, sqlTranslatingExpressionVisitorFactory, selectExpressionFactory, resultOperatorHandler)
    		{ }
    
    		public override Expression HandleResultOperator(EntityQueryModelVisitor entityQueryModelVisitor, ResultOperatorBase resultOperator, QueryModel queryModel)
    			=> resultOperator is CountDistinctResultOperator ?
    				HandleCountDistinct(entityQueryModelVisitor, resultOperator, queryModel) :
    				base.HandleResultOperator(entityQueryModelVisitor, resultOperator, queryModel);
    
    		private Expression HandleCountDistinct(EntityQueryModelVisitor entityQueryModelVisitor, ResultOperatorBase resultOperator, QueryModel queryModel)
    		{
    			var queryModelVisitor = (RelationalQueryModelVisitor)entityQueryModelVisitor;
    			var selectExpression = queryModelVisitor.TryGetQuery(queryModel.MainFromClause);
    			var inputType = queryModel.SelectClause.Selector.Type;
    			if (CanEvalOnServer(queryModelVisitor)
    				&& selectExpression != null
    				&& selectExpression.Projection.Count == 1)
    			{
    				PrepareSelectExpressionForAggregate(selectExpression, queryModel);
    				var expression = selectExpression.Projection[0];
    				var subExpression = new SqlFunctionExpression(
    					"DISTINCT", inputType, new[] { expression.UnwrapAliasExpression() });
    				selectExpression.SetProjectionExpression(new SqlFunctionExpression(
    					"COUNT", typeof(int), new[] { subExpression }));
    				return new ResultTransformingExpressionVisitor<int>(
    					queryModelVisitor.QueryCompilationContext, false)
    					.Visit(queryModelVisitor.Expression);
    			}
    			else
    			{
    				queryModelVisitor.RequiresClientResultOperator = true;
    				var typeArgs = new[] { inputType };
    				var distinctCall = Expression.Call(
    					typeof(Enumerable), "Distinct", typeArgs,
    					queryModelVisitor.Expression);
    				return Expression.Call(
    					typeof(Enumerable), "Count", typeArgs,
    					distinctCall);
    			}
    		}
    
    		private static bool CanEvalOnServer(RelationalQueryModelVisitor queryModelVisitor) =>
    			!queryModelVisitor.RequiresClientEval && !queryModelVisitor.RequiresClientSelectMany &&
    			!queryModelVisitor.RequiresClientJoin && !queryModelVisitor.RequiresClientFilter &&
    			!queryModelVisitor.RequiresClientOrderBy && !queryModelVisitor.RequiresClientResultOperator &&
    			!queryModelVisitor.RequiresStreamingGroupResultOperator;
    	}
    }
 
