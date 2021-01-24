C#
/// <summary>
/// A comparison between multiple properties in the outer query and the
///  result of a subquery
/// Note: DB support of row value constructor is required
/// </summary>
[Serializable]
public class MultiPropertiesSubqueryExpression : SubqueryExpression
{
	private readonly string[] _propertyNames;
	public MultiPropertiesSubqueryExpression(string[] propertyNames, string op, DetachedCriteria dc)
		: base(op, null, dc)
	{
		_propertyNames = propertyNames;
	}
	protected override SqlString ToLeftSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery)
	{
		return new SqlString("(", string.Join(", ", _propertyNames.Select(pn => criteriaQuery.GetColumns(criteria, pn)).SelectMany(x => x)), ")");
	}
}
And example of usage:
C#
DetachedCriteria detachedCriteria = DetachedCriteria.For(typeof(Bar))
	//.Add(...) //Add some conditions
	.SetProjection(Projections.ProjectionList().Add(Property.ForName("Prop1")).Add(Property.ForName("Prop2")));
var result = session.CreateCriteria(typeof(Foo))
					.Add(new MultiPropertiesSubqueryExpression(new[] {"Prop1", "Prop2"}, "in", detachedCriteria))
					.List<Foo>();
