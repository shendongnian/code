    Excel.Application app = new Excel.Application();
    app.Visible = true;
    app.Workbooks.Add("");
    app.Workbooks.Add(@"c:\MyWork\WorkBook1.xls");
      app.Workbooks.Add(@"c:\MyWork\WorkBook2.xls");
    for (int i = 2; i <= app.Workbooks.Count; i++)
    {
        for (int j = 1; j <= app.Workbooks[i].Worksheets.Count;j++ )
        {
            Excel.Worksheet ws = app.Workbooks[i].Worksheets[j];
            ws.Copy(app.Workbooks[1].Worksheets[1]);
        }
    }
