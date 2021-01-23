    //Create a dataset typed
    DataSet ds = new DataSet();
    //Constructor a dataset from Dataset Model, dataset use for crystal report
    DataSet1.print_salesDataTable tb = new DataSet1.print_salesDataTable();
    //Queries with the conditions is ID
    QLGiayDepEntities list = new QLGiayDepEntities();
    var result = (from n in list.print_sales
                  where n.OrderID == txtID.Text
                  select n).ToList();
    //Fill result to table
    foreach (print_sales item in result)
    {
        tb.Rows.Add(
            item.OrderID,
            item.DateOrder,
            item.NameEmployee,
            item.Total,
            item.Recieved,
            item.Discount,
            item.Sum,
            item.FromCustomer,
            item.Notes,
            item.Barcode,
            item.Name,
            item.ColorName,
            item.SizeID,
            item.Quantity,
            item.Price,
            item.SubTotal);
    }
    //checking to print
    if (result == null)
    {
        MessageBox.Show("null");
    }
    else
    {
        ds.Tables.Add(tb);
        CrystalReportSales1.SetDataSource(ds);
        crystalReportViewer1.ReportSource = CrystalReportSales1;
        crystalReportViewer1.PrintReport();
    }
