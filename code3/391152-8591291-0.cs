		/// <summary>
		/// Show an InputBox similar to the pre-.NET InputBox functionality. Returns the original value when Cancel was pressed.
		/// </summary>
		/// <param name="OriginalValue">Pre-populated value in the input box</param>
		/// <param name="PromptText">Prompt text displayed on the form</param>
		/// <param name="Caption">Window caption</param>
		/// <returns>InputBoxResult structure containing both the DialogResult and the input text. Warning: The input text will always be returned regardless of the DialogResult, so don't use it if the DialogResult is Cancel.</returns>
		public static InputBoxResult Show(string OriginalValue = "", string PromptText = "", string Caption = "") {
			InputBox form = new InputBox {
			   Text = Caption,
				lblPrompt = {Text = PromptText}, 
				txtInput = {Text = OriginalValue}
			};
			InputBoxResult res = new InputBoxResult();
			res.Result = form.ShowDialog();
			res.Input = form.txtInput.Text;
			return res;
		}
