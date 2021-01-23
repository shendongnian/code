    [TestClass]
    public class RomanToDecimalTest
    {
        [TestMethod]
        public void Roman_I_1()
        {
            Assert.AreEqual(1, Roman.From("I"));
        }
        [TestMethod]
        public void Roman_II_2()
        {
            Assert.AreEqual(2, Roman.From("II"));
        }
        [TestMethod]
        public void Roman_III_3()
        {
            Assert.AreEqual(3, Roman.From("III"));
        }
        [TestMethod]
        public void Roman_IV_4()
        {
            Assert.AreEqual(4, Roman.From("IV"));
        }
        [TestMethod]
        public void Roman_V_5()
        {
            Assert.AreEqual(5, Roman.From("V"));
        }
        [TestMethod]
        public void Roman_IX_9()
        {
            Assert.AreEqual(9, Roman.From("IX"));
        }
        [TestMethod]
        public void Roman_X_10()
        {
            Assert.AreEqual(10, Roman.From("X"));
        }
        [TestMethod]
        public void Roman_XLIX_49()
        {
            Assert.AreEqual(49, Roman.From("XLIX"));
        }
        [TestMethod]
        public void Roman_L_50()
        {
            Assert.AreEqual(50, Roman.From("L"));
        }
        [TestMethod]
        public void Roman_C_100()
        {
            Assert.AreEqual(100, Roman.From("C"));
        }
        [TestMethod]
        public void Roman_CD_400()
        {
            Assert.AreEqual(400, Roman.From("CD"));
        }
        [TestMethod]
        public void Roman_D_500()
        {
            Assert.AreEqual(500, Roman.From("D"));
        }
        [TestMethod]
        public void Roman_CM_900()
        {
            Assert.AreEqual(900, Roman.From("CM"));
        }
        [TestMethod]
        public void Roman_M_1000()
        {
            Assert.AreEqual(1000, Roman.From("M"));
        }
        [TestMethod]
        public void Roman_MMMMMMMMMMMCMLXXXIV_11984()
        {
            Assert.AreEqual(11984, Roman.From("MMMMMMMMMMMCMLXXXIV"));
        }
    }
