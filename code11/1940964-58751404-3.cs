`
var parameter = _db.Parameter[0]; // you may need to handle that there's at least 1 item.
for (int i = 1; i < _db.Parameter.Count; i++)
{
    var param = _db.Parameter[i];
    if (param.EndDate > givenDate)
    { // param is good
        if (parameter.EndDate == null || parameter.EndDate > param.EndDate)
            parameter = param; // replace parameter with param
    }
    else if (parameter.EndDate != null && parameter.EndDate < givenDate)
    { // parameter precedes given date, replace it!
        parameter = param;
    }
}
`
This will iterate through your list just once, unlike the other solutions provided so far.
If you **MUST** use LINQ and want to iterate once, maybe you can use the below, which will return a dynamic though, so you need to convert it back to a `Parameter`. It works by replacing the `NULL` with `DateTime.MaxValue` so that when you do an `OrderBy`, the entries that were `NULL` would be ordered at the bottom.
`
var param = _db.Parameter
    .Select(x => new
    {
        ID = x.ID,
        EndDate = (x.EndDate.HasValue) ? x.EndDate : DateTime.MaxValue,
        Value = x.Value
    })
    .OrderBy(x => x.EndDate)
    .FirstOrDefault();
var parameter = new Parameter()
    {
        ID = param.ID,
        EndDate = (param.EndDate == DateTime.MaxValue) ? null : param.EndDate,
        Value = param.Value
    };
