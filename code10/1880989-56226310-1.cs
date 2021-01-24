    IGenerateReport helper = new ExcelHelper();
    helper.Test();
    helper.GenerateReport();
    helper = new CoreHelper();
    helper.Test();
    helper.GenerateReport();
    HelperBase helper2 = new ExcelHelper();
    helper2.Test();
    helper2.GenerateReport();
