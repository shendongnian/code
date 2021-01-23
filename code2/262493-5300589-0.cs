	internal class MyClass
	{
		private const string ButtonTypeAsString = "Button";
		private const string CheckBoxTypeAsString = "CheckBox";
		private const string TextBoxTypeAsString = "TextBox";
		private static string GetTypeAsString(Control control)
		{
			string result = String.empty;
			if (result.Length == 0 && (control as Button) != null)
			{
				result = MyClass.ButtonTypeAsString;
			}
			
			if (result.Length == 0 && (control as CheckBox) != null)
			{
				result = MyClass.CheckBoxTypeAsString;
			}
			
			if (result.Length == 0 && (control as TextBox) != null)
			{
				result = MyClass.TextBoxTypeAsString;
			}
			
			if (result.Length == 0)
			{
				throw new InvalidOperationException("Control type is not handled by this method.");
			}
			
			return result;
		}
		internal static void DoSomething(Control control)
		{
			string controlTypeAsString = MyClass.GetTypeAsString(control);
			
			switch (controlTypeAsString)
			{
				case MyClass.ButtonTypeAsString:
					// Button stuff
					break;
				
				case MyClass.CheckBoxTypeAsString:
					// Checkbox stuff
					break;
				
				case MyClass.TextBoxTypeAsString:
					// TextBox stuff
					break;
				
				default:
					throw new InvalidOperationException("Unexpected Control type");
			}
		}
	}
