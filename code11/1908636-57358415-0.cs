C#
var requestInfos = new List<(int Id1, int Id2)>();
requestInfos.Add((1, 2));
requestInfos.Add((1, 3));
var someTable = new List<(int Id1, int Id2, string someColumn)>();
someTable.Add((1, 2, "12"));
someTable.Add((2, 2, "22"));
someTable.Add((1, 3, "13"));
var parameter = Expression.Parameter(typeof((int Id1, int Id2, string someColumn)));
Expression body = Expression.Constant(true);
foreach (var requestInfo in requestInfos)
{
    var tableId1 = Expression.MakeMemberAccess(parameter, typeof((int Id1, int Id2, string someColumn)).GetMember("Item1")[0]);
    var tableId2 = Expression.MakeMemberAccess(parameter, typeof((int Id1, int Id2, string someColumn)).GetMember("Item2")[0]);
    var paramId1 = Expression.MakeMemberAccess(Expression.Constant(requestInfo), typeof((int Id1, int Id2)).GetMember("Item1")[0]);
    var paramId2 = Expression.MakeMemberAccess(Expression.Constant(requestInfo), typeof((int Id1, int Id2)).GetMember("Item2")[0]);
    var and = Expression.And(Expression.Equal(paramId1, tableId1), Expression.Equal(paramId2, tableId2));
    body = Expression.OrElse(body, and);
    Expression<Func<(int Id1, int Id2, string someColumn), bool>> buf = i => i.Id1 == requestInfo.Id1 && i.Id2 == requestInfo.Id2;
}
var func = Expression.Lambda<Func<(int Id1, int Id2, string someColumn), bool>>(body, new[] {parameter});
var query = someTable.AsQueryable().Where(func);
Still this is quite complicated and gets out of hand quickly. The Predicate Builder (also mentioned by Gibbon's answer) should be a more scalable approach
