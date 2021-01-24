var resultOfFirstDbContext = //new FirstDto(); initialize the object of the first query
var resultOfTheSecondDbContext = //new SecondDto(); new List<SecondDto>(); initialize the object of the second query
using (var dbContext = new TestHHCEntities())
{
    resultOfFirstDbContext = (from alertEvents in dbContext.Test_AlertEvents
                where alertEvents.IsAlert
                group alertEvents by alertEvents.MemberIssuesID into g)
                .OrderBy(p => p.AlertDate)
                .Select(x => new FirstDto
                             {
                                 Property1 = x.Property1, .....
                             }).FirstOrDefault();
}
using (var secondDbContext = new Test2_14Entities())
{
      resultOfTheSecondDbContext = secondDbContext.Entities
                                   .Where(second => 
                                       second.Property1 == resultOfFirstDbContext.Property1 
                                       && ....)
                                 //.ToList(); or .FirstOrDefault();
}
//you can now use `resultOfTheSecondDbContext` here
