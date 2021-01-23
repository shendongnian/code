    	[Test]
		public void IsValid_SelectedValueDifferent_ReturnTrue()
		{
			//Arrange
			var validator = new SelectedValueValidator { SelectedValue = "123" };
			//Act
			bool result = validator.IsValid();
			//Assert
			Assert.That(result, Is.True);
		}
		[Test]
		public void IsValid_SelectedValueIsTheSame_ReturnFalse()
		{
			//Arrange
			var validator = new SelectedValueValidator ();
			//Act
			bool result = validator.IsValid();
			//Assert
			Assert.That(result, Is.False);
		}
