        public static void OpenXLSFiles()
        {
            string[] folder = Directory.GetFiles(@"d:\pricelist\", "*.xls");
            foreach (string file in folder)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook wbv = excel.Workbooks.Open(file);
                    wbv.Close();
                    excel.Quit();
                    Marshal.ReleaseComObject(wbv);
                    Marshal.ReleaseComObject(excel);
                }
                catch (Exception)
                {
                    Console.WriteLine(string.Format("File is corrupt : {0}", file));
                }
            }
        }
