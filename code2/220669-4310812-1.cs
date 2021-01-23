     **Code is Edited**
     DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("Col");
            dt.Columns.Add(dc1);
            
            for(int i=0;i<10;i++)
            {
                DataRow dr = dt.NewRow();
                 dr["Col"] = i.ToString();
                 dt.Rows.Add(dr);
            }
          
            DataColumn dc = new DataColumn("Col1"); 
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 1;
            dc.DataType = typeof(Int32);
            dt.Columns.CollectionChanged += new CollectionChangeEventHandler(Columns_CollectionChanged);
            dt.Columns.Add(dc);
            DataRow dr1 = dt.NewRow();
                dt.Rows.Add(dr1);
        
        void Columns_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            DataColumn dc = (e.Element as DataColumn);
            if (dc != null && dc.AutoIncrement)
            {
                long i = dc.AutoIncrementSeed;
                foreach (DataRow drow in dc.Table.Rows)
                {
                    drow[dc] = i;
                    i++;
                }
            }
        }
