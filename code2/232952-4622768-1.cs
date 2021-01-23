                //Test Add/Remove Col
                //Create dummy dataset for testing
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn("col1", typeof(DateTime));
                dt.Columns.Add(dc);
                dc = new DataColumn("col2", typeof(DateTime));
                dt.Columns.Add(dc);
                dc = new DataColumn("col3", typeof(DateTime));
                dt.Columns.Add(dc);
                dc = new DataColumn("col4", typeof(DateTime));
                dt.Columns.Add(dc);
                DataRow dr = dt.NewRow();
                dr[0] = Convert.ToDateTime("01/01/2011");
                dr[1] = Convert.ToDateTime("02/01/2011");
                dr[2] = Convert.ToDateTime("03/01/2011");
                dr[3] = Convert.ToDateTime("04/01/2011");
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                //Create object of the class
                TestAddRemoveCol obj = new TestAddRemoveCol();
                //Add column at the specific location in the dataset
                DataTable dt2 = obj.AddCol(ds, "EndDate", typeof(String), 2);
                //Copy data from one column to another
                DataTable dt3 = obj.CopyCol(dt2, "col3", "EndDate");
                //Remove column with the specific name
                obj.RemoveCol(dt3, "col3");
