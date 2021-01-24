    public class SoftwareUnderTest(string xsdPath)
    {
        private void ThisDoesSomethingWithXSD()
        {
            var fil = File.Open(xsdPath);
        }
    }
    [TestClass]
    public class TestCode()
    {
        [TestMethod]
        public void Test()
        {
            // Instantiate the component under test:
                var sUT = new SoftwareUnderTest("\\Testpath\text.xsd");
                
                //ACT
                //ToDo: write your testcode
                //Assert
            }
        }
    }
