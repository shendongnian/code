    public void SetSubDataSource(object sender, SubreportProcessingEventArgs e)
    {
        var mainSource = ((LocalReport) sender).DataSources["MainDataSet1"];
        var orderId = int.Parse(e.Parameters["OrderID"].Values.First());
        var subSource = ((List<Order>)mainSource.Value).Single(o => o.OrderID == orderId).Suppliers;
        e.DataSources.Add(new ReportDataSource("SubDataSet1", subSource));
    }
