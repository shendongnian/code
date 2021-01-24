c#
{
//The method where you call dtJ and dtJR from the database:
ToTreeView(tvBomView, dtj, dtJR);
}
`ToTreeView(..)` method:
c#
private void ToTreeView(TreeView tv, DataTable dt1, DataTable dt2)
{
    tv.SuspendLayout();
    tv.Nodes.Clear();
    //Create a temp IEnumerable of anonymous type:
    var items = dt1.Rows.Cast<DataRow>()
        .Select(x => new
        {
            Parent = x,
            Children = dt2.Rows.Cast<DataRow>()
            .Where(y => y["suffix"].ToString() == x["suffix"].ToString())
        });
    foreach(var item in items)
    {
        var parentNode = tv.Nodes.Add("job", item.Parent["suffix"].ToString());
        foreach(var child in item.Children)
        {
            parentNode.Nodes.Add("oper", $"Oper: {child["operNum"].ToString()}");
        }
    }
    tv.EndUpdate();
}
Or just:
c#
private void ToTreeView(TreeView tv, DataTable dt1, DataTable dt2)
{
    tv.SuspendLayout();
    tv.Nodes.Clear();
    dt1.Rows.Cast<DataRow>()
        .ToList()
        .ForEach(x =>
        {
            var p = tv.Nodes.Add("job", x["Suffix"].ToString());
            dt2.Rows.Cast<DataRow>()
            .Where(y => x["Suffix"].ToString() == y["Suffix"].ToString())
            .ToList()
            .ForEach(y => p.Nodes.Add("oper", $"Oper: {y["operNum"].ToString()}"));
        });
    tv.EndUpdate();
}
