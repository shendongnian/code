c#
public static partial class QueryableExtensions {
	public static IQueryable<TResult> TrimProjection<TResult>( this IQueryable<TResult> source, IEnumerable<string> targetPropeties ) {
		var visitor = new ProjectionReducer<TResult>( targetPropeties );
		var expression = visitor.Visit( source.Expression );
		if( expression != source.Expression )
			return source.Provider.CreateQuery<TResult>( expression );
		return source;
	}
	private class ProjectionReducer<TResult> : ExpressionVisitor {
		private readonly List<string> propNames;
		public ProjectionReducer( IEnumerable<string> targetPropeties ) {
			if( targetPropeties == null || !targetPropeties.Any( ) ) {
				throw new ArgumentNullException( nameof( targetPropeties ) );
			}
			this.propNames = targetPropeties.ToList( );
		}
		protected override Expression VisitNew( NewExpression node ) {
			return base.VisitNew( node );
		}
		protected override Expression VisitLambda<T>( Expression<T> node ) {
			//if the node returns the type we are acting upon
			if( node.ReturnType == typeof( TResult ) ) {
				//create a new expression from this one that is the same thing with some of the bindings omitted
				var mie = (node.Body as MemberInitExpression);
				var currentBindings = mie.Bindings;
				var newBindings = new List<MemberBinding>( );
				foreach( var b in currentBindings ) {
					if( propNames.Contains( b.Member.Name, StringComparer.CurrentCultureIgnoreCase ) ) {
						newBindings.Add( b );
					}
				}
				Expression testExpr = Expression.MemberInit(
					mie.NewExpression,
					newBindings
				);
				return Expression.Lambda( testExpr, node.Parameters );
			}
			return base.VisitLambda( node );
		}
	}
}
