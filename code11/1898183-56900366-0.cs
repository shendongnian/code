    [TestFixtureSource("DataFromExcel")]
    public class MyTestFixture : BaseClassForTheTest
    {
        IEnumerable<TestCaseData> DataFromExcel()
        {
            // Read the Excel file
            // For each row of data you want to use
            //     yield return new TestCaseData(/*test fixture args here*/);
        }
        public MyTestFixture(/* your arg list */)
        {
            // Save each arg in a private member
        }
        [Test, Order(1)]
        TestcodeForHomePage()
        {
            // Code that uses the saved values from the constructor
        }
        [Test,Order(2)]
        TestcodeForNextPage()
        {
            // Code that uses the saved values from the constructor
        }
    }
