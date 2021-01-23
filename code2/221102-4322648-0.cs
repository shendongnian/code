    var combinedrows = from dt1 in DsResults.Tables[0].AsEnumerable()
                                  join dt2 in DsResults.Tables[1].AsEnumerable() on        dt1.Field<string>("MethodName") equals dt2.Field<string>("MethodName")
                               select new { sp = dt1.Field<string>("Tab1_col1"), Method = dt1.Field<string>("MethodName"), _class = dt1.Field<string>("Class"),
                                            BLLMethod = dt1.Field<string>("Tab2_col2")
                               }; 
            
            DataTable finaldt = new DataTable("FinalTable");
            finaldt.Columns.Add(new DataColumn("sp", typeof(string)));
            finaldt.Columns.Add(new DataColumn("Method", typeof(string)));
            finaldt.Columns.Add(new DataColumn("Class", typeof(string)));
            finaldt.Columns.Add(new DataColumn("BLLMethod", typeof(string)));
            DataRow newrow = finaldt.NewRow();           
            foreach (var row in combinedrows)
            {
                DataRow dr = finaldt.NewRow();
                dr["sp"] = row.sp;
                dr["Method"] = row.Method;
                dr["Class"] = row._class;
                dr["BLLMethod"] = row.BLLMethod;
                finaldt.Rows.Add(dr);
            }
