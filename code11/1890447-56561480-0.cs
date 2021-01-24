    public class UserValidate : IUserValidate {
        private EPINMiddleWareAPIContext context;
        public UserValidate(EPINMiddleWareAPIContext context) {
            this.context = context;
        }
        //This method is used to check the user credentials
        public bool Login(string username, string password) {
            return context.Companies.Any(user =>
                user.userName.Equals(username, StringComparison.OrdinalIgnoreCase)
                && user.password == password
            );
        }
    }
