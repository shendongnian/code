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
