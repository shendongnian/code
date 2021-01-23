    [TestClass]
    public class AtomicBooleanTest
    {
        [TestMethod]
        public void TestAtomicBoolean()
        {
            AtomicBoolean b = new AtomicBoolean();
            Assert.IsFalse(b.Value);
            b = new AtomicBoolean(false);
            Assert.IsFalse(b.Value);
            b = new AtomicBoolean(true);
            Assert.IsTrue(b.Value);
            //when Value is already true, FalseToTrue fails
            b.Value = true;
            Assert.IsFalse(b.FalseToTrue());
            Assert.IsTrue(b.Value);
            //when Value is already false, TrueToFalse fails
            b.Value = false;
            Assert.IsFalse(b.TrueToFalse());
            Assert.IsFalse(b.Value);
            //Value not changed if SetWhen fails
            b.Value = false;
            Assert.IsFalse(b.SetWhen(true, true));
            Assert.IsFalse(b.Value);
            //Value not changed if SetWhen fails
            b.Value = true;
            Assert.IsFalse(b.SetWhen(false, false));
            Assert.IsTrue(b.Value);
        }
    }
