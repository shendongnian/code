csharp
var result = flats.GroupBy(x => x.Group1).Select(group1 => new Group1()
{
    Name = group1.Key,
    Group2 = group1.GroupBy(x => x.Group2).Select(group2 => new Group2()
    {
        Name = group2.Key,
        Values = group2.Select(x => x.Value).ToArray()
    }).ToArray()
});
