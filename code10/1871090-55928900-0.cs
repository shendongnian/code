	public static IForm<MyClass> BuildForm()
	{
		var formBuilder = new FormBuilder<MyClass>()
			.Field(nameof(FirstName))
			.Field(nameof(LastName))
			.Confirm("Is this okay? {*}")
			.Prompter(PromptAsync)
			;
		return formBuilder.Build();
	}
	/// <summary>
	/// Here is the method we're using for the PromptAsyncDelgate.
	/// </summary>
	private static async Task<FormPrompt> PromptAsync(IDialogContext context, FormPrompt prompt,
		MyClass state, IField<MyClass> field)
	{
		var preamble = context.MakeMessage();
		var promptMessage = context.MakeMessage();
		// Check to see if the form is on the navigation step
		if (field.Name.Contains("navigate") && prompt.Buttons.Any())
		{
			// If it's on the navigation step,
			// we want to change or remove the No Preference line
			if (you_want_to_change_it)
			{
				var noPreferenceButton = prompt.Buttons.Last();
				// Make sure the Message stays the same or else
				// FormFlow won't know what to do when this button is clicked
				noPreferenceButton.Message = noPreferenceButton.Description;
				noPreferenceButton.Description = "Back"; 
			}
			else if(you_want_to_remove_it)
			{
				prompt.Buttons.RemoveAt(prompt.Buttons.Count - 1);
			}
		}
		if (prompt.GenerateMessages(preamble, promptMessage))
		{
			await context.PostAsync(preamble);
		}
		await context.PostAsync(promptMessage);
		return prompt;
	}
