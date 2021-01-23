    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = 5m;
            var b = 5.1m;
            var c = 5.122m;
            var d = 10.235544545m;
    
            var ar = DecToStr.Work(a);
            var br = DecToStr.Work(b);
            var cr = DecToStr.Work(c);
            var dr = DecToStr.Work(d);
    
            Assert.AreEqual(ar, "5.0");
            Assert.AreEqual(br, "5.1");
            Assert.AreEqual(cr, "5.122");
            Assert.AreEqual(dr, "10.235544545");
        }
    }
    
    public class DecToStr
    {
        public static string Work(decimal val)
        {
            if (val * 10 % 10 == 0)
                return val.ToString("0.0");
            else
                return val.ToString();
        }
    }
