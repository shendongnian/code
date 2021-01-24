    public void CreateDocument(DataTable dataTable )
    {
       try
            {
                dataTable.Clear();
                dataTable.Columns.Add("Name");
                dataTable.Columns.Add("Marks");
                DataRow _ravi = dataTable.NewRow();
                _ravi["Name"] = "ravi";
                _ravi["Marks"] = "500";
                dataTable.Rows.Add(_ravi);
                using (SLDocument sl = new SLDocument())
                {                  
                    sl.ImportDataTable("A1", dataTable, true);
                    var style = sl.CreateStyle();
                    //PatternValues.Solid, 
                    style.Fill.SetPattern(PatternValues.Solid, SLThemeColorIndexValues.Accent2Color, SLThemeColorIndexValues.Accent4Color);
                    sl.SetCellStyle("A1:Z1", style);
                    sl.SaveAs("Test.xlsx");
                }
            }
            catch (MissingMethodException ex)
            {
            }
    }
