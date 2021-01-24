using Excel = Microsoft.Office.Interop.Excel;
Excel.Application xlApp;
Excel.WorkBook xlWB;
Excel.Worksheet xlWS;
xlApp = new Excel.Application();
xlWB = xlApp.Workbooks.Open("C:\path\to\file.xlsx");
xlWS = xlWB.Worksheets["Sheet1"];
xlWS.Cells[1, "D"].Interior.Color = Color.GreenYellow;
## To get color from a cell
using Excel = Microsoft.Office.Interop.Excel;
Excel.Application xlApp;
Excel.WorkBook xlWB;
Excel.Worksheet xlWS;
xlApp = new Excel.Application();
xlWB = xlApp.Workbooks.Open("C:\path\to\file.xlsx");
xlWS = xlWB.Worksheets["Sheet1"];
int color_n = System.Convert.ToInt32((xlWS.Cells[1, "D"]).Interior.Color);
Color color = System.Drawing.ColorTranslator.FromOle(color_n);
MessageBox.Show(color.ToString()); // Outputs the color of a cell
