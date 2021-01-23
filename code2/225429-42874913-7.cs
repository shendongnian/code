    [TestClass]
    public class Code
    {
        [TestMethod]
        public void IdentifyGeneratorTest()
        {
            var set = new HashSet<string>();
            for (int i = 1; i <= 1000000; i++)
            {
                var id = IdentifyGenerator.WebHash();
                if (!set.Add(id))
                    Assert.Fail("IdentifyGenerator duplicate found");
            }
        }
    }
