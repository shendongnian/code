        [TestMethod]
        public void TestContains()
        {
            var e1 = MyEnum.One | MyEnum.Two;
            Assert.IsTrue( e1.Contains(MyEnum.Two) );
            var e2 = MyEnum.One | MyEnum.Four;
            Assert.IsFalse(e2.Contains(MyEnum.Two));
        }
