		/// <summary>
		/// Represents the results from an InputBox.Show call, including the DialogResult
		/// and the input data. Note that the input data is always populated with the
		/// user-entered data regardless of the DialogResult - this is inconsistent with
		/// the old InputBox behavior and may change in the future.
		/// </summary>
		public struct InputBoxResult {
			/// <summary>
			/// Describes the way the dialog was resolved (OK / Cancel)
			/// </summary>
			public DialogResult Result { get; set; }
			/// <summary>
			/// User-entered text
			/// </summary>
			public string Input { get; set; }
			/// <summary>
			/// Translate this result into a string for easy debugging
			/// </summary>
			/// <returns></returns>
			public override string ToString() {
				return "Result: " + Result.ToString() +
					"\r\nInput: " + Input.ToString();
			}
		}
