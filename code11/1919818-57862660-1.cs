    public class OfferService : IOfferService {
        private readonly IUserService userService;
    
        public OfferService(IUserService userService) {
            this.userService = userService;            
        }
    
        public bool SomeMethod() {
    
            //...use userService
    
        }
    } 
    
    
    public class UserService : IUserService {
        
        public UserService(ISomeOtherService someotherService)
            string key = someotherService.GetKey();
            string value = someotherService.GetValue();
            
            //...
        }
    
        //...
    }
