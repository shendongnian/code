    public class ClassOne
    {
        private ExcelDocument excelDoc;
        public ClassOne(ExcelDocument document)
        {
            excelDoc = document;
        }
        public void DoSomethingWithExcelData()
        {
            excelDoc.SomeValue = "Modified in ClassOne";
        }
    }
    public class ClassTwo
    {
        private ExcelDocument excelDoc;
        public ClassTwo(ExcelDocument document)
        {
            excelDoc = document;
        }
        public void DoSomethingWithExcelData()
        {
            excelDoc.SomeOtherValue = "Modified in ClassTwo";
        }
    }
