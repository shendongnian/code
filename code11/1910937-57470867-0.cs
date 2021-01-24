c#
var query = from x in ListB
            join y in ListA
            on x.C1C2 equals y.C1C2
            select new { Source = y, Target = x };
//Update metadata from ListA to ListB
foreach (var x in query)
{
    x.Target.Desc1 = x.Source.Desc1;
    x.Target.Desc2 = x.Source.Desc2;
    x.Target.DataType = x.Source.DataType;
}
