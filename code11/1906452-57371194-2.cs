C#
session.CreateQuery(
	"select a from A a where a.Id in "
		+ "(select min(ga.Id) from A ga group by ga.X)").List<A>();
`
But unfortunatly it can't be expressed in LINQ in one query due to some bug (in NHibernate 5.2 group by subquery throws exception). So for now in LINQ it can be done via 2 queries:
C#
var subquery = session.Query<A>()
	.GroupBy(ga => ga.X)
	.Select(ga => ga.Min(a => a.Id))
	.ToList();//when bug is fixed this ToList call can be omitted and make results retrieved in single db call
	
var results = session.Query<A>().Where(a => subquery.Contains(a.Id)).ToList();
Also it seems "group by" in subquery can be also avoided so single query LINQ version is also possible:
C#
var results = session.Query<A>()
     .Where(a => a.Id == session.Query<A>().Where(sa => sa.X == a.X).Select(sa => sa.Id).Min())
     .ToList();
