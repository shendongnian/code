        [TestMethod]
        public void Test_Of_Generic_Type_Name()
        {
            var myBuilder = new GenericNamer();
            Assert.AreEqual<string>("BasicMath", myBuilder.GetName<BasicMath>());
        }
