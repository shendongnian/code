    [ExcelCommand(MenuName="My Macros", MenuText="Set MyTag value")]
    public static void MySetterMacro()
    {
        var app = (Microsoft.Office.Interop.Excel.Application) ExcelDnaUtil.Application;
        var range = app.Range["MyTag"];
        range.Value = "Hello there!";
    }                
