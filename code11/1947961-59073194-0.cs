    int ntab = 5;
            Table t = docs.Tables[ntab];
            Rows rows = t.Rows;
            Columns cols = t.Columns;
            
            for (int i = 1; i < rows.Count; i++) {
                string ftxt = "";
                    for (int j = 1; j <= cols.Count; j++) {
                      Cell cell = rows[i].Cells[j];
                      Range r = cell.Range;
                    string txt = r.Text;
                    ftxt = ftxt + " | " + txt; 
                 
                }
                File.AppendAllText(@"c:\temp\test.txt", ftxt.ToString() + Environment.NewLine);
                Console.WriteLine(ftxt);
                
            }
            Console.WriteLine("\n");
            ((_Document)docs).Close();
            ((_Application)word).Quit();
            
        }
