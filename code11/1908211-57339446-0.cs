    public partial class Home : Window {
        private readonly IGitApiService _gitApiService;
    
        public Home(IGitApiService gitApiService) {
             _gitApiService = gitApiService;
        }
    
        public User User { get; set; }
    
        //...
    }
