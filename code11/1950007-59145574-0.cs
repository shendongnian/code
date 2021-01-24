csharp
private void button_Click(object sender, EventArgs e)
{
    List<Identity> listOfIdentity = new List<Identity>()
    {
        new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.550"), PcName="Test3"},
        new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.300"), PcName="Test1"},
        new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.350"), PcName="Test2"},
        new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.400"), PcName="Test2"},
        new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.200"), PcName="Test1"},
        new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.500"), PcName="Test1"},
        new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.250"), PcName="Test1"},
        new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.450"), PcName="Test1"},
        new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.150"), PcName="Test1"}
    };
    List<Identity> sortedIdentity = listOfIdentity.OrderBy(x => x.QCTime).ThenBy(x => x.PcName).ToList(); // here i order by time and then pc name
    var result = sortedIdentity.Skip(1).Aggregate(new List<List<Identity>> { new List<Identity> { sortedIdentity[0] } }, (lists, curr) =>
    {
        if (curr.PcName == lists.Last()[0].PcName)
            lists.Last().Add(curr);
        else
            lists.Add(new List<Identity> { curr });
        return lists;
    });
}
It iterates over each element and checks, if it's *PcName* is the same as previous. If it is, it goes on the same list, else new list is created with this element.
