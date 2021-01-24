    public class Program
    {
        private static void Main()
        {
            // "Read" an excel document and set properties in this class
            var excelDoc = new ExcelDocument
            {
                SomeValue = "original Value",
                SomeOtherValue = "original value"
            };
            // Instantiate the classes above so they can use the document without re-reading it
            var class1 = new ClassOne(excelDoc);
            var class2 = new ClassTwo(excelDoc);
            // Output the original values of our document
            Console.WriteLine(excelDoc);
            // Have each class do their operations on the document
            class1.DoSomethingWithExcelData();
            class2.DoSomethingWithExcelData();
            // Output the values again to show how the two independent classes 
            // manipulated the same document (and without reading it)
            Console.WriteLine(excelDoc);
            GetKeyFromUser("\nDone! Press any key to exit...");
        }
    }
