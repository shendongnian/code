    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore.Query.Expressions;
    using Microsoft.EntityFrameworkCore.Query.Sql;
    using Microsoft.EntityFrameworkCore.Storage;
    using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
    using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Sql.Internal;
    
    namespace Microsoft.EntityFrameworkCore
    {
    	public static partial class CustomDbContextOptionsBuilderExtensions
    	{
    		public static DbContextOptionsBuilder UseCustomNpgsqlQuerySqlGenerator(this DbContextOptionsBuilder optionsBuilder)
    		{
    			optionsBuilder.ReplaceService<IQuerySqlGeneratorFactory, CustomNpgsqlQuerySqlGeneratorFactory>();
    			return optionsBuilder;
    		}
    	}
    }
    
    namespace Npgsql.EntityFrameworkCore.PostgreSQL.Query.Sql.Internal
    {
    	class CustomNpgsqlQuerySqlGeneratorFactory : NpgsqlQuerySqlGeneratorFactory
    	{
    		private readonly INpgsqlOptions npgsqlOptions;
    		public CustomNpgsqlQuerySqlGeneratorFactory(QuerySqlGeneratorDependencies dependencies, INpgsqlOptions npgsqlOptions)
    			: base(dependencies, npgsqlOptions) => this.npgsqlOptions = npgsqlOptions;
    		public override IQuerySqlGenerator CreateDefault(SelectExpression selectExpression) =>
    			new CustomNpgsqlQuerySqlGenerator(Dependencies, selectExpression, npgsqlOptions.ReverseNullOrderingEnabled);
    	}
    
    	public class CustomNpgsqlQuerySqlGenerator : NpgsqlQuerySqlGenerator
    	{
    		public CustomNpgsqlQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies, SelectExpression selectExpression, bool reverseNullOrderingEnabled)
    			: base(dependencies, selectExpression, reverseNullOrderingEnabled) { }
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
