                //simulating data 
                DataTable peopletbl = new DataTable("Person");
                peopletbl.Columns.Add("Name", typeof(string));
                peopletbl.Columns.Add("SurName", typeof(string));
    
                DataRow row = peopletbl.NewRow();
                row["Name"] = "Alan";
                row["SurName"] = "Turing";
                peopletbl.Rows.Add(row);
                //until now, you already have the data    
                //at the view.....
                //just use index properly
                foreach (DataRow iRow in peopletbl.Rows)
                {
                    var name = iRow["Name"];
                    var surName = iRow["SurName"];
                }
