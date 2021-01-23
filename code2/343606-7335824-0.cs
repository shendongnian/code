	public class Validator
	{
		public Validator(string code, bool settingsCheck, Button button, object sender)
		{
			Code = code;
			IsValid = sender != null && button != null && sender.Equals(button);
		}
		public bool IsValid { get; private set; }
		public string Code { get; private set; }
	}
