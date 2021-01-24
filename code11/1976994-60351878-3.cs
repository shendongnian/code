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
---
**Edit: 3 Tables Version**
c#
private void ToTreeView(TreeView tv, DataTable dt1, DataTable dt2, DataTable dt3)
{
    tv.SuspendLayout();
    tv.Nodes.Clear();
    dt1.Rows.Cast<DataRow>()
        .ToList()
        .ForEach(x =>
        {
            var p = tv.Nodes.Add("job", x["suffix"].ToString());
            dt2.Rows.Cast<DataRow>()
            .Where(y => x["suffix"].ToString() == y["suffix"].ToString())
            .ToList()
            .ForEach(y =>
            {
                var c = p.Nodes.Add("oper", $"Oper: {y["operNum"].ToString()}");
                dt3.Rows.Cast<DataRow>()
                .Where(z => z["suffix"].ToString() == y["suffix"].ToString() &&
                z["operNum"].ToString() == y["operNum"].ToString())
                .ToList()
                .ForEach(n => c.Nodes.Add("seq", $"Seq: {n["seq"].ToString()}"));
            });
        });
    tv.EndUpdate();
}
Please consider this as a quick-and-dirty workaround and consider what have been mentioned in the comments. Check out the related posts below.
> **Related**
>
> <sup>[Populate TreeView from DataTable](https://stackoverflow.com/a/53924862/10216583)</sup>  
> <sup> [Populate WinForms TreeView from DataTable](https://stackoverflow.com/a/810801/10216583)</sup>  
> <sup> [Populate TreeView from Database using C#](http://sharp-coders.com/populate-treeview-from-database-using-csharp/)</sup>
