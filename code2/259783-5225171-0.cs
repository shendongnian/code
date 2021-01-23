        class BaseClass { }
        class DerivedClass : BaseClass { }
        [Test]
        public void TestBaseName()
        {
            var a = new DerivedClass();
            Assert.AreEqual(a.GetType().BaseType.Name, "BaseClass");
        }
