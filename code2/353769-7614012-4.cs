	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class RequireAtLeastOneAttribute: ValidationAttribute {
		/// <summary>
		/// This identifier is used to group properties together.
		/// Pick a number and assign it to each of the properties
		/// among which you wish to require one.
		/// </summary>
		public int GroupId { get; set; }
		/// <summary>
		/// This defines the message key any errors will be associated
		/// with, so that they can be accessed via the front end using
		/// @Html.ValidationMessage(errorMessageKey).
		/// </summary>
		public string ErrorMessageKey { get; set; }
		public override bool IsValid(object value) {
			// Find all properties on the class having a "PropertyGroupAttribute"
			// with GroupId matching the one on this attribute
			var typeInfo = value.GetType();
			var propInfo = typeInfo.GetProperties();
			foreach (var prop in propInfo) {
				foreach (PropertyGroupAttribute attr in prop.GetCustomAttributes(typeof(PropertyGroupAttribute), false)) {
					if (attr.GroupId == this.GroupId
						&& !string.IsNullOrWhiteSpace(prop.GetValue(value, null).GetString())) {
						return true;
					}
				}
			}
			return false;
		}
	}
