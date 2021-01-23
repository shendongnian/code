    DataTable _dt=new DataTable();//public 
    
    void AddColumns()
    {
     _dt.Columns.Add(new DataColumn("ID", typeof(int)));
     _dt.Columns.Add(new DataColumn("mark", typeof(int)));
    }
