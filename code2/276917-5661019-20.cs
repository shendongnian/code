    private void Parsing_String(string filename)    
    {
        DataTable dt = CreateDataTable();
        foreach (String str in File.ReadLines(filename))
        {
          String[] strCols = str.Split(Convert.ToChar(" "));
          DataRow Row = dt.NewRow(); //Where dt is a DataTable
          for (int i =0; i < strCols.length; i++)
          {
               Row[i] = strCols[i].Substring(2); //This will start reading from the third character
          }
          dt.Rows.Add(Row);
         }
          listView1.ItemsSource = dt.Rows;
    }
    //**EDIT**: Just in case you don't have a datatable and you want to create a small one:
    public DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            new string[] { "Column 1", "Column 2", "Column 3", "Column 4", "Column 5", "Column 6" }
                .ToList()
                .ForEach(c => { dt.Columns.Add(new DataColumn(c)); });
            return dt;
        }
