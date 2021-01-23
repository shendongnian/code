    [TestFixture]
    public class SINTests
    {
        private int SinNumber = 123456782;
        [Test]
        public void TestValidNumber()
        {
            Assert.IsTrue(Program.IsValidLength(SinNumber));
        }
        
        [Test]
        public void TestRemoveLastDigit()
        {
            Assert.AreEqual(12345678, Program.RemoveLastDigit(SinNumber));
        }
        [Test]
        public void TestExtractEvenDigit()
        {
            int sn = 12345678;
            int[] array = new int[] { 2,4,6,8 };
            Assert.AreEqual(array, Program.ExtractEvenDigits(sn));
        }
        [Test]
        public void TestAddOddDigits()
        {
            int sn = 12345678;
            int result = 1 + 3 + 5 + 7;
            Assert.AreEqual(result, Program.AddOddDigits(sn));
        }
        [Test]
        public void TestDoubleEvenDigits()
        {
            int sn = 12345678;
            int[] original = new int[] { 2, 4, 6, 8 };
            int[] array = new int[] { 4, 8, 12, 16 };
            Assert.AreEqual(array, Program.DoubleDigits(original));
        }
        [Test]
        public void TestOddDigits()
        {
            int sn = 12345678;
            Assert.AreEqual(16, Program.AddOddDigits(sn));
        }
    }
