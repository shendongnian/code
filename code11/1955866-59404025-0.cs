        public void SetPropertySetsValue()
        {
            string value = "value";
            MockObjectType mockObject = new MockObjectType(); // or create object of ObjectType
            ClassUnderTest classUnderTest = new ClassUnderTest();
            var result = classUnderTest.SetProperty(value, mockObject);
            Assert.AreEqual(value, mockObject.Name);
        }
