        var myRange = Globals.ThisAddIn.Application.ActiveDocument.Range();
        foreach (List<List<string>> ClassTable in new List<List<List<string>>> { new List<List<string>> { new List<string> { "A" }, new List<string> { "B" } }, new List<List<string>> { new List<string> { "C" }, new List<string> { "D" } } })
        {
            // tbl is a "Microsoft.Office.Interop.Word.Table"            
            // myRange is like MyDoc.Range(ref missing, ref missing)            
            Microsoft.Office.Interop.Word.Table tbl = null;
            try
            {
                tbl = Globals.ThisAddIn.Application.ActiveDocument.Tables.Add(myRange, ClassTable.Count(), 3);
                tbl.Borders.Enable = 1;
                int RowCounter = 1;
                foreach (var item in ClassTable)
                {
                    int ColumnCounter = 1;
                    foreach (string str in item)
                    {
                        tbl.Cell(RowCounter, ColumnCounter).Range.Text = str;
                        ColumnCounter++;
                    }
                    RowCounter++;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
     }
