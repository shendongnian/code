        static void Main(string[] args)
        {
           Application app = new Application();
            app.Visible = true;
            Workbook w1 = app.Workbooks.Add(@"D:\MyDownload\result2.xlsx");
            Workbook w2 = app.Workbooks.Add(@"D:\MyDownload\merge1.xlsx");
            Workbook w3 = app.Workbooks.Add(@"D:\MyDownload\merge2.xlsx");
            for (int i = 2; i <= app.Workbooks.Count; i++)
            {
                for (int j = 1; j <= app.Workbooks[i].Worksheets.Count; j++)
                {
                    Worksheet ws = (Worksheet)app.Workbooks[i].Worksheets[j];
                    ws.Copy(app.Workbooks[1].Worksheets[1]);
                }
            }
            app.Workbooks[1].SaveCopyAs(@"D:\MyDownload\result2.xlsx");
            w1.Close(0);
            w2.Close(0);
            w3.Close(0);
            app.Quit();
        }
    }
