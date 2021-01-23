    DataTable Sale=new DataTable("sale");
    Sale.Columns.Add("department",typeof(string));
    Sale.Columns.Add("sale",typeof(double));
    Sale.Rows.Add("a",20);
    Sale.Rows.Add("a",30);
    Sale.Rows.Add("b",25);
    
    DataTable Return=new DataTable("Return");
    Return.Columns.Add("department",typeof(string));
    Return.Columns.Add("return",typeof(double));
    Return.Rows.Add("a",21);
    Return.Rows.Add("a",23);
    Return.Rows.Add("a",24);
    Return.Rows.Add("c",29);
