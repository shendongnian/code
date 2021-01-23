		private readonly IValidator<ItemViewModel> validator = new ItemValidator(); 
        //Assumes your fluent validation is in ItemValidator and your view model is ItemViewModel
		[Test]
		public void Headline_ShouldNotBeEmpty()
		{
			validator.ShouldHaveValidationErrorFor(f => f.message, string.Empty);
		}
