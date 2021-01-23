    [TestClass]
    public class HeaderParserTest
    {
         [TestMethod]
         public void TestHeader() 
         {
             ParserTestHelper.Test(
                () => new HeaderParser(),
                () => /* generate data */,
                () => /* validate results */);
         }
    }
