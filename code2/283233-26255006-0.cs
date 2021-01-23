	public class CustomMembershipProvider : MembershipProvider {
	
        private LoginValidationType ValidationType;
        // new method
        public bool ValidateUser(string username, string password, LoginValidationType validationType = LoginValidationType.WebsiteSpecific) {
            ValidationType = validationType;
            return ValidateUser(username, password);
        }
        // the original method
		public override bool ValidateUser(string username, string password) {
            // do stuff with username, password and this.ValidationType
		}
