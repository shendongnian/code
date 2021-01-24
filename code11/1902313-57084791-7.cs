    private static void Main()
    {
        var excelDoc = new ExcelDocument
        {
            SomeValue = "original Value",
            SomeOtherValue = "original value"
        };
        ClassOne.DoSomethingWithExcelData(excelDoc);
