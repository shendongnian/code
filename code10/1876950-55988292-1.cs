                //geting data from sql. ok so far
                DataTable table = new DataTable("Person");
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("SurName", typeof(string));
    
                DataRow row = table.NewRow();
                row["Name"] = "Alan";
                row["SurName"] = "Turing";
                table.Rows.Add(row);
                //until now, you already have the data    
                //at the view.....
                //just use index properly
                foreach (DataRow iRow in table.Rows)
                {
                    var name = iRow["Name"];
                    var surName = iRow["SurName"];
                }
