        private MockClass classUnderTest;
        private ValidationContext context;
        FeeTimeUnitValidator setup(string attributeUnderTest)
        {
            classUnderTest = new MockClass();
            classUnderTest.Fee = 0;
            var propertyInfo = typeof(MockClass).GetProperty(attributeUnderTest);
            var validatorArray = propertyInfo.GetCustomAttributes(typeof(FeeTimeUnitValidator), true);
            Assert.AreEqual(1, validatorArray.Length);
            var validator = validatorArray[0];
            Assert.IsTrue(validator.GetType().Equals(typeof(FeeTimeUnitValidator)));
            context = new ValidationContext(classUnderTest, null, null);
            return (FeeTimeUnitValidator)validator;
        }
