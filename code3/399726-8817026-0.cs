        Microsoft.Office.Interop.Excel.Application app = Globals.ThisAddIn.Application;
        string version = app.Version;
        if (version == "14.0")
        {
            //If Excel 2010 do something
        }
        else if (version == "12.0")
        {
            //If Excel 2007 do something else
        }
