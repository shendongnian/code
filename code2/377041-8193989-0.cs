    public class PhoneNumber : IValidatableObject {
		public long Id { get; set; }
		public string Tel1 { get; set; }
		public string Tel2 { get; set; }
	public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
    {
			var field1 = new[] { "Tel1" };
			var field2 = new[] { "Tel2" };
			if (string.IsNullOrEmpty(Tel1))
				if (String.IsNullOrEmpty(Tel2))
	yield return new ValidationResult("At least Fill one of Tel1 or Tel2‏", field1);
			if (string.IsNullOrEmpty(Tel2))
			if (String.IsNullOrEmpty(Tel1))
	yield return new ValidationResult("At least Fill one of Tel1 or Tel2", field2);
		}
	}
