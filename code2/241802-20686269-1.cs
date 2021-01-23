    [TestClass]
    public class TestApplication
    {
        [TestMethod]
        public void TestMyArgument()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); //  this makes any Console.Writes etc go to sw
                Program.Main(new[] { "argument" });
                var result = sw.ToString();
                Assert.AreEqual("expected", result);
            }
        }
    }
