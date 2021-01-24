    public class Basehub : Hub {
        protected IUserProfileProvide userProfileProvider;
    
        public Basehub(IUserProfileProvide userProfileProvider) {
            this.userProfileProvider = userProfileProvider;
        }
    }
