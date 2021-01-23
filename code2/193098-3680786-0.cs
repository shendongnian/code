    public class MyComparer:Comparer<string>
    {
        private readonly CompareInfo compareInfo;
        public MyComparer()
        {
            compareInfo = CompareInfo.GetCompareInfo(CultureInfo.InvariantCulture.Name);
        }
        public override int Compare(string x, string y)
        {
            return compareInfo.Compare(x, y, CompareOptions.OrdinalIgnoreCase);
        }
    }
    public class Class1
    {
        [Test]
        public void TestMethod1()
        {
            var rg = new String[] { 
        "x", "z", "y", "-less", ".net", "- more", "a", "b"
    };
            Array.Sort(rg, new MyComparer());
            Assert.AreEqual(
                "- more,-less,.net,a,b,x,y,z",
                String.Join(",", rg)
            );
          
            
        }
    }
