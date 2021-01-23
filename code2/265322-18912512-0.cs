	public class Person
	{
		[CustomValidation(typeof(Person), "validateDOB")]
		public DateTime DateOfBirth { get; set; }
		//field (or property) limits that we could look-up
		private static DateTime _MinDate = new DateTime(1, 1, 1900);
		private static DateTime _MaxDate = new DateTime(31, 12, 2999);
		//this method must be public and static and take a single
		//parameter: the field to validate
		public static ValidationResult validateDOB(DateTime dateOfBirth)
		{
			string errorMsg = "";
			if (dateOfBirth < _MinDate)
			{
				errorMsg = "Date too early";
			}
			else if (dateOfBirth > _MaxDate)
			{
				errorMsg = "Date too late";
			}
			return errorMsg == "" ? null : new ValidationResult(errorMsg);
		}
	}
