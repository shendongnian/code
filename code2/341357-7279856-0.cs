    // Assumes that customerConnection is a valid SqlConnection object.
    // Assumes that orderConnection is a valid OleDbConnection object.
    SqlDataAdapter custAdapter = new SqlDataAdapter(
      "SELECT * FROM dbo.Customers", customerConnection);
    OleDbDataAdapter ordAdapter = new OleDbDataAdapter(
      "SELECT * FROM Orders", orderConnection);
    DataSet customerOrders = new DataSet();
    custAdapter.Fill(customerOrders, "Customers");
    ordAdapter.Fill(customerOrders, "Orders");
    DataRelation relation = customerOrders.Relations.Add("CustOrders",
    customerOrders.Tables["Customers"].Columns["CustomerID"],
    customerOrders.Tables["Orders"].Columns["CustomerID"]);
    foreach (DataRow pRow in customerOrders.Tables["Customers"].Rows)
    {
       Console.WriteLine(pRow["CustomerID"]);
       foreach (DataRow cRow in pRow.GetChildRows(relation))
       Console.WriteLine("\t" + cRow["OrderID"]);
    }
