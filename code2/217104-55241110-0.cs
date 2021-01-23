     [Test]
        [TestCase("textbox", true, "Text is empty", null, false)]
        [TestCase("textbox", false, "Text is empty", null, true)]
        public void Test_Component_Validation_and_ValidationText__Whether_IsMandatory_IsSet(string textbox, bool isMandatory, string validationText, string value, bool expectedValue)
                {
                //Arrange
                var mockPublicPortalService = new Mock<IPublicPortalService>();
                PublicAssessmentController controller = new PublicAssessmentController(mockPublicPortalService.Object);
                // Set Component properties 
                var Component = new Component()
                {
                    ComponentDatatype = textbox,
                    IsMandatory = isMandatory,
                    ValidationText = validationText,
                    Value = value
                };
                var context = new ValidationContext(Component);
                //Act
                var results = new List<ValidationResult>();
                var isModelStateValid = Validator.TryValidateObject(Component, context, results, true);
                // Assert
                Assert.AreEqual(expectedValue, isModelStateValid);
                if (isModelStateValid == false)
                {
                    Assert.IsTrue(results.Any(x => x.ErrorMessage == validationText));
                };
         
        }
