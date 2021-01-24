     public ActionResult Index()
            {
                DataTable table = new DataTable("Person");
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("SurName", typeof(string));
    
                DataRow row = table.NewRow();
                row["Name"] = "Alan";
                row["SurName"] = "Turing";
    
                table.Rows.Add(row);
    
                //just use index properly
                foreach (DataRow iRow in table.Rows)
                {
                    var name = iRow["Name"];
                    var surName = iRow["SurName"];
                }
    
                return View(table);
            }
