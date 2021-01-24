    public class NotificationHub: BaseHub {
    
        public NotificationHub(IUserProfileProvide userProfileProvider) 
            : base(userProfileProvider) { }
    
        public async Task InvokeMe(string message) {
            IUserProfile profile = userProfileProvider.InitUserProfile(Context); //context populated
    
            //...
    
            await Clients.All.SendAsync("invoked",message); 
        }   
    }
