        var accApp = new Microsoft.Office.Interop.Access.Application();
        accApp.OpenCurrentDatabase(@tests.DatabasePath);
        Microsoft.Office.Interop.Access.Dao.Database cdb = accApp.CurrentDb();
        Microsoft.Office.Interop.Access.Dao.Recordset rst =
    cdb.OpenRecordset(
        "SELECT * FROM Users",
        Microsoft.Office.Interop.Access.Dao.RecordsetTypeEnum.dbOpenSnapshot);
        while (!rst.EOF)
        {
            Console.WriteLine(rst.Fields["username"].Value);
            rst.MoveNext();
        }
        rst.Close();
        accApp.CloseCurrentDatabase();
        accApp.Quit();
