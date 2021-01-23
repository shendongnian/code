        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void BoxingTest()
        {
            IComparable i = 42;
            byte b = (byte)i;      //exception: not allowed to unbox an int to any type other than int
            Assert.AreEqual(42, b);
            Assert.Fail();
        }
