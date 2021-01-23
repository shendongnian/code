        [TestMethod]
        public void TestInRangeIsValidWhenFeeNonZero()
        {
            // Arrange
            var validator = setup("attributeUnderTest");
            classUnderTest.Fee = 10;
            // Act
            ValidationResult value12 = validator.GetValidationResult(12, context);
            ValidationResult value1 = validator.GetValidationResult(1, context);
            ValidationResult value5 = validator.GetValidationResult(5, context);
            // Assert
            Assert.AreEqual(ValidationResult.Success, value12);
            Assert.AreEqual(ValidationResult.Success, value1);
            Assert.AreEqual(ValidationResult.Success, value5);
        }
