    public class SoftwareUnderTest()
    {
        private void ThisDoesSomethingWithXSD()
        {
            var fil = File.Open(ApplicationDirectory + "\myxsd.xsd");
        }
    }
    [TestClass]
    public class TestCode()
    {
        [TestMethod]
        public void Test()
        {
            using (ShimsContext.Create())
            {
                // Arrange:
                // Shim DateTime.Now to return a fixed date:
                System.Fakes.ShimFile.Open =
                    () => { return File.Open("\\Testpath\text.xsd"); };
                // Instantiate the component under test:
                var sUT = new SoftwareUnderTest();
                
                //ACT
                //ToDo: write your testcode
                //Assert
            }
        }
    }
