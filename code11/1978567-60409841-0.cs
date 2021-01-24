    public class ExportImportExcel
        {
            #region Constructor
            public ExportImportExcel()
            {
    
            }
            #endregion Constructor
    
            #region Methods
            public static void ExportToExel(DataGridView DGV, System.Data.DataTable Dt)
            {
                try
                {
                    //Install-Package Microsoft.Office.Interop.Excel
                    Microsoft.Office.Interop.Excel.Application exeleapp = new Microsoft.Office.Interop.Excel.Application();
                    var exelbook = exeleapp.Workbooks.Add(XlSheetType.xlWorksheet);
                    var exelworksheet = (Worksheet)(exelbook.Worksheets[1]);
                    exelworksheet.DisplayRightToLeft = true;
    
                    int clmncnt = DGV.Columns.Count;
                    Range[] rng = new Range[clmncnt];
    
                    for (int x = 0; x < clmncnt; x++)
                    {
                        string celladress = Convert.ToString(Convert.ToChar(Convert.ToByte(x + 65))) + "1";
                        rng[x] = exelworksheet.get_Range(celladress, celladress);
                        rng[x].Value2 = DGV.Columns[x].HeaderText;
                    }
    
                    int j = 2;
                    foreach (DataRow r in Dt.Rows)
                    {
                        for (int k = 0; k < clmncnt; k++)
                        {
                            string celladress = Convert.ToString(Convert.ToChar(Convert.ToByte(k + 65))) + j.ToString();
                            rng[k] = exelworksheet.get_Range(celladress, celladress);
                            rng[k].Value2 = r[k].ToString();
                        }
                        j++;
                    }
                    exeleapp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);              
                }
            }
    
            #endregion Methods
        }
