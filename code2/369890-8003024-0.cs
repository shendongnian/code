    var oGrouped = dt.Rows.Cast<DataRow>().GroupBy(r => r[1].ToString() + " " + r[2].ToString());
    foreach (var oClient in oGrouped)
    {
        var oClientNode = this.TreeView.Nodes.Add(oClient.Key);
        foreach (var oInvoice in oClient)
        {
            oClientNode.Nodes.Add(oInvoce[3].ToString());
        }
    }
