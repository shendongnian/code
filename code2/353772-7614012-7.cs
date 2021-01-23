	public class User: IValidatableObject {
		...
		#region IValidatableObject Members
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
			var results = new List<ValidationResult>();
			// This keeps track of whether each "RequireAtLeastOne" group has been satisfied
			var groupStatus = new Dictionary<int, bool>();
			// This stores the error messages for each group as defined
			// by the RequireAtLeastOneAttributes on the model
			var errorMessages = new Dictionary<int, ValidationResult>();
			// Find all "RequireAtLeastOne" property validators 
			foreach (RequireAtLeastOneAttribute attr in Attribute.GetCustomAttributes(this.GetType(), typeof(RequireAtLeastOneAttribute), true)) {
				groupStatus.Add(attr.GroupId, false);
				errorMessages[attr.GroupId] = new ValidationResult(attr.ErrorMessage, new string[] { attr.ErrorMessageKey });
			}
			// For each property on this class, check to see whether
			// it's got a PropertyGroup attribute, and if so, see if
			// it's been populated, and if so, mark that group as "satisfied".
			var propInfo = this.GetType().GetProperties();
			bool status;
			foreach (var prop in propInfo) {
				foreach (PropertyGroupAttribute attr in prop.GetCustomAttributes(typeof(PropertyGroupAttribute), false)) {
					if (groupStatus.TryGetValue(attr.GroupId, out status) && !status
						&& !string.IsNullOrWhiteSpace(prop.GetValue(this, null).GetString())) {
						groupStatus[attr.GroupId] = true;
					}
				}
			}
			// If any groups did not have at least one property 
			// populated, add their error messages to the
			// validation result.
			foreach (var kv in groupStatus) {
				if (!kv.Value) {
					results.Add(errorMessages[kv.Key]);
				}
			}
			return results;
		}
		#endregion
	}
