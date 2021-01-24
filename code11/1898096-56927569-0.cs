    [ExcelFunction(Name="DoSomething",IsMacroType=true)]
    string DoSomething()
    {
         var xl = ExcelDna.Application;    
         var callerCell = xl.Caller;
         var row = getRow(excelReference.RowFirst+1, callerCell.WorkSheet) ;
    }
