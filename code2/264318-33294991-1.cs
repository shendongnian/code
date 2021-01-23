        [Test]
        public void ExplodeRange()
        {
            var output = Range.Explode(5, 9);
            Assert.AreEqual(5, output.Count);
            Assert.AreEqual(5, output[0]);
            Assert.AreEqual(6, output[1]);
            Assert.AreEqual(7, output[2]);
            Assert.AreEqual(8, output[3]);
            Assert.AreEqual(9, output[4]);
        }
        [Test]
        public void ExplodeSingle()
        {
            var output = Range.Explode(1, 1);
            Assert.AreEqual(1, output.Count);
            Assert.AreEqual(1, output[0]);
        }
        [Test]
        public void InterpretSimple()
        {
            var output = Range.Interpret("50");
            Assert.AreEqual(1, output.Count);
            Assert.AreEqual(50, output[0]);
        }
        [Test]
        public void InterpretComplex()
        {
            var output = Range.Interpret("1,5-9,14,16,17,20-24");
            Assert.AreEqual(14, output.Count);
            Assert.AreEqual(1, output[0]);
            Assert.AreEqual(5, output[1]);
            Assert.AreEqual(6, output[2]);
            Assert.AreEqual(7, output[3]);
            Assert.AreEqual(8, output[4]);
            Assert.AreEqual(9, output[5]);
            Assert.AreEqual(14, output[6]);
            Assert.AreEqual(16, output[7]);
            Assert.AreEqual(17, output[8]);
            Assert.AreEqual(20, output[9]);
            Assert.AreEqual(21, output[10]);
            Assert.AreEqual(22, output[11]);
            Assert.AreEqual(23, output[12]);
            Assert.AreEqual(24, output[13]);
        }
        [ExpectedException(typeof (FormatException))]
        [Test]
        public void InterpretBad()
        {
            Range.Interpret("powdered toast man");
        }
