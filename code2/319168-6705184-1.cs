    [TestClass]
    public class HeaderParserTest : ParserTest<IHeader>
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
