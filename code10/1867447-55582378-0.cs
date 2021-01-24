    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ExcelTest {
        public class Information {
            public Information(string name, int sum) {
                Name = name;
                Sum = sum;
            }
    
            public string Name { get; set; }
            public int Sum { get; set; }
        }
    
        class Program {
            private static async Task Main() {
                const string filePath = @"D:\file.xlsx";
                var excel = new Excel.Application {Visible = true, EnableAnimations = false};
                var wkb = Open(excel, filePath);
    
                var calculation = await CalculateAllWorksheetsAsync(wkb);
    
                foreach (var item in calculation) {
                    Console.WriteLine($"{item.Name} - {item.Sum}");
                }
    
                excel.EnableAnimations = true;
                wkb.Close(true);
                excel.Quit();
                Console.Read();
            }
    
            private static async Task<List<Information>> CalculateAllWorksheetsAsync(Excel.Workbook wkb) {
                var tasks = wkb.Worksheets.Cast<Excel.Worksheet>().Select(CalculateSingleWorksheetAsync);
                var results = await Task.WhenAll(tasks);
                return results.ToList();
            }
    
            private static async Task<Information> CalculateSingleWorksheetAsync(Excel.Worksheet wks) {
                int result = await Task.Run(() =>
                    Enumerable.Range(1, 123).Sum(index => (int) (wks.Cells[index, 1].Value2)));
    
                Console.WriteLine($"{wks.Name} - {result}");
                return new Information(wks.Name, result);
            }
    
            private static Excel.Workbook Open(Excel.Application excelInstance,
                string fileName, bool readOnly = false,
                bool editable = true, bool updateLinks = true) {
                return excelInstance.Workbooks.Open(
                    fileName, updateLinks, readOnly,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, editable, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
            }
        }
    }
