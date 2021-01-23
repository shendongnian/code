    DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Col1", typeof(string));
                dt.Columns.Add("Col2", typeof(string));
                dt.Columns.Add("ConcatenatedField", typeof(string), "Col1 + ' : ' +Col2"); 
    
                Enumerable.Range(1, 10).ToList().ForEach(i => dt.Rows.Add(i, string.Concat("Col1", i), string.Concat("Col2", i)));
    
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "ConcatenatedField";
