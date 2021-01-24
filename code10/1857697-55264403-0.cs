    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore.Query.Expressions;
    using Microsoft.EntityFrameworkCore.Query.Sql;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
    using Microsoft.EntityFrameworkCore.SqlServer.Query.Sql.Internal;
    
    namespace Microsoft.EntityFrameworkCore
    {
    	public static partial class CustomDbContextOptionsBuilderExtensions
    	{
    		public static DbContextOptionsBuilder UseCustomSqlServerQuerySqlGenerator(this DbContextOptionsBuilder optionsBuilder)
    		{
    			optionsBuilder.ReplaceService<IQuerySqlGeneratorFactory, CustomSqlServerQuerySqlGeneratorFactory>();
    			return optionsBuilder;
    		}
    	}
    }
    
    namespace Microsoft.EntityFrameworkCore.SqlServer.Query.Sql.Internal
    {
    	class CustomSqlServerQuerySqlGeneratorFactory : SqlServerQuerySqlGeneratorFactory
    	{
    		private readonly ISqlServerOptions sqlServerOptions;
    		public CustomSqlServerQuerySqlGeneratorFactory(QuerySqlGeneratorDependencies dependencies, ISqlServerOptions sqlServerOptions)
    			: base(dependencies, sqlServerOptions) => this.sqlServerOptions = sqlServerOptions;
    		public override IQuerySqlGenerator CreateDefault(SelectExpression selectExpression) =>
    			new CustomSqlServerQuerySqlGenerator(Dependencies, selectExpression, sqlServerOptions.RowNumberPagingEnabled);
    	}
    
    	public class CustomSqlServerQuerySqlGenerator : SqlServerQuerySqlGenerator
    	{
    		public CustomSqlServerQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies, SelectExpression selectExpression, bool rowNumberPagingEnabled)
    			: base(dependencies, selectExpression, rowNumberPagingEnabled) { }
    		protected override RelationalTypeMapping InferTypeMappingFromColumn(Expression expression)
    		{
    			if (expression is UnaryExpression unaryExpression)
    				return InferTypeMappingFromColumn(unaryExpression.Operand);
    			if (expression is ConditionalExpression conditionalExpression)
    				return InferTypeMappingFromColumn(conditionalExpression.IfTrue) ?? InferTypeMappingFromColumn(conditionalExpression.IfFalse);
    			return base.InferTypeMappingFromColumn(expression);
    		}
    	}
    }
