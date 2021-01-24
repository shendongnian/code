    public interface IUser {
        string UserName { get; }
        string Password { get; }
    }
    public partial User : IUser { }  //must be in the correct namespace for partial to work
    public partial ArmUser : IUser { } //must be in the correct namespace for partial to work
    
    public class Test {
        public void TestWebService() {
            var ws = new WebService<WebServiceWRG>();
            ws.SearchClaim(new WebServiceWRGClient(), new GraceUser(), 
                "https://trustonline.delawarecpf.com/tows/webservicewrg.svc", "userName", "password");  
        }
    }
    public class WebService<T> {             
        public void SearchClaim<TOne, TTwo>(TOne entity1, TTwo entity2, string url, string userName, string password) 
            where TOne : class
            where TTwo : IUser  // limits the TTwo class to implement IUser
        {
            var client = entity1;
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            var endpoint = new EndpointAddress(url);
            var channelFactory = new ChannelFactory<T>(binding, endpoint);
            var webService = channelFactory.CreateChannel();
            var user = entity2;
            user.UserName = webService.EncryptValue(userName);
            user.Password = webService.EncryptValue(password);
            var response = client.ClaimSearch(user, "", "", 12345, GraceStatuscode.NotSet, "");
        }
    }
