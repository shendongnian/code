    var dt = new DataTable();
    dt.Columns.Add("Price", typeof(decimal));
    dt.Rows.Add(10);
    decimal doublePrice = dt.Rows[0].Compute<decimal>("Price * 2");
    Console.WriteLine(doublePrice);
