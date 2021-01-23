    private static void MergeWorkbooks(string destinationFilePath, params string[] sourceFilePaths)
    {
      var app = new Application();
      app.DisplayAlerts = false; // No prompt when overriding
      // Create a new workbook (index=1) and open source workbooks (index=2,3,...)
      Workbook destinationWb = app.Workbooks.Add();
      foreach (var sourceFilePath in sourceFilePaths)
      {
        app.Workbooks.Add(sourceFilePath);
      }
      // Copy all worksheets
      Worksheet after = destinationWb.Worksheets[1];
      for (int wbIndex = app.Workbooks.Count; wbIndex >= 2; wbIndex--)
      {
        Workbook wb = app.Workbooks[wbIndex];
        for (int wsIndex = wb.Worksheets.Count; wsIndex >= 1; wsIndex--)
        {
          Worksheet ws = wb.Worksheets[wsIndex];
          ws.Copy(After: after);
        }
      }
      // Close source documents before saving destination. Otherwise, save will fail
      for (int wbIndex = 2; wbIndex <= app.Workbooks.Count; wbIndex++)
      {
        Workbook wb = app.Workbooks[wbIndex];
        wb.Close();
      }
      // Delete default worksheet
      after.Delete();
      // Save new workbook
      destinationWb.SaveAs(destinationFilePath);
      destinationWb.Close();
      app.Quit();
    }
