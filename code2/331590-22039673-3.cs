    [TestClass]
    public class DecimalToRomanTest
    {
        [TestMethod]
        public void Roman_1_I()
        {
            Assert.AreEqual("I", Roman.To(1));
        }
        [TestMethod]
        public void Roman_2_II()
        {
            Assert.AreEqual("II", Roman.To(2));
        }
        [TestMethod]
        public void Roman_3_III()
        {
            Assert.AreEqual("III", Roman.To(3));
        }
        [TestMethod]
        public void Roman_4_IV()
        {
            Assert.AreEqual("IV", Roman.To(4));
        }
        [TestMethod]
        public void Roman_5_V()
        {
            Assert.AreEqual("V", Roman.To(5));
        }
        [TestMethod]
        public void Roman_9_IX()
        {
            Assert.AreEqual("IX", Roman.To(9));
        }
        [TestMethod]
        public void Roman_10_X()
        {
            Assert.AreEqual("X", Roman.To(10));
        }
        [TestMethod]
        public void Roman_49_XLIX()
        {
            Assert.AreEqual("XLIX", Roman.To(49));
        }
        [TestMethod]
        public void Roman_50_L()
        {
            Assert.AreEqual("L", Roman.To(50));
        }
        [TestMethod]
        public void Roman_100_C()
        {
            Assert.AreEqual("C", Roman.To(100));
        }
        [TestMethod]
        public void Roman_400_CD()
        {
            Assert.AreEqual("CD", Roman.To(400));
        }
        [TestMethod]
        public void Roman_500_D()
        {
            Assert.AreEqual("D", Roman.To(500));
        }
        [TestMethod]
        public void Roman_900_CM()
        {
            Assert.AreEqual("CM", Roman.To(900));
        }
        [TestMethod]
        public void Roman_1000_M()
        {
            Assert.AreEqual("M", Roman.To(1000));
        }
        [TestMethod]
        public void Roman_11984_MMMMMMMMMMMCMLXXXIV()
        {
            Assert.AreEqual("MMMMMMMMMMMCMLXXXIV", Roman.To(11984));
        }
    }
