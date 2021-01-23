        [TestMethod]
        public void TestMethod1()
        {
            var myObject = new AnObject { AString = "someString" };
            
            var myOtherObject = new AnotherObject();
            var newObject = myObject.Duplicate(myOtherObject);
            Assert.IsTrue(newObject.AString=="someString");
            var newObject2 = myObject.Duplicate(1);
            Assert.IsTrue(newObject2 is Int32);
        }
