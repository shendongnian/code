     Assuming it is a web based application  :  
    You are not binding the grid with null data source:
        use this to clear out the data and bind them.
        
            DataTable ds = new DataTable();
            ds = null;
            grd.DataSource = ds;
            grd.Update();
        
        IF you need to remove column name also use the below code snippet:
        
        for (int i = 0; grd.Columns.Count > i; )
        {
            grd.Columns.RemoveAt(i);
        }
