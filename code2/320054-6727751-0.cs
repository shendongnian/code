    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HashSet<string> hashset = new HashSet<string>();
            hashset.Add("AAA");
            hashset.Add("BBB");
            hashset.Add("CCC");
            Assert.AreEqual<string>("AAABBBCCC", hashset.AllToString());
        }
    }
    public static class HashSetExtensions
    {
        public static string AllToString(this HashSet<string> hashset)
        {           
            lock (hashset) 
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in hashset)
                    sb.Append(item);
                return sb.ToString();
            }
        }
    } 
