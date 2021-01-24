var query = context.Students.AsQueryable();
if(request.Id.HasValue && request.Id > 0)
{
    //equal query
    query = query.Where(x => x.Id == request.Id.Value);
    /* greater than or less than and equal to query
    *query = query.Where(x => x.Id >= request.Id.Value) or query.Where(x => x.Id <= request.Id.Value) or query.Where(x => x.Id != request.Id.Value)
    */
}
if(request.Age.HasValue && request.Age > 0)
{
    query = query.Where(x => x.Id == request.Age.Value);
    //same applies to top depending on your condition, can be !=, <=, >= or between (< && >)
}
if(request.Dob.HasValue)
{
    query = query.Where(x => x.Id == request.Dob.Value);
    //same applies to top depending on your condition, can be !=, <=, >=
}
//the ONLY part which the query will be executed
var result = query.ToList();
