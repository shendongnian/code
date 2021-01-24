public class WebService<T1, T2, T3> {
    private T1 _client;
    private T3 _user;
	
	//No T2
    public WebService(T1 wsClient, T3 wsUser) {
        _client = wsClient;
        _user = wsUser;
		//No interface
    }
    public void CallWebService(string url, string userName, string password) {
        (...)
        var channelFactory = new ChannelFactory<T2>(binding, endpoint);   <---- use the T2 type
        (...)
    }
}
and then
var someServiceA = new WebService<WebServiceWRGClient, WebServiceWRG, Whatever_GRACE_GRACES_User()_returns_here>(new WebServiceWRGClient(), new GRACE_GRACES.User());
*(Please note the var because the type is not `WebService` but `WebService<X,Y,Z>`)*
----
# Next step
I don't think you need generics for the client and the user, and the next step could be:
public class WebService<T> {
    private Baseclassofallclients _client;
    private UserTypeHere _user;
    public WebService( Baseclassofallclients wsClient, UserTypeHere  wsUser) {
        _client = wsClient;
        _user = wsUser;
		//No interface
    }
    public void CallWebService(string url, string userName, string password) {
        (...)
        var channelFactory = new ChannelFactory<T>(binding, endpoint);   <---- use the T type here
        (...)
    }
and then
var someServiceA = new WebService<WebServiceWRG>(new WebServiceWRGClient(), new GRACE_GRACES.User());
var someServiceB = new WebService<WebServiceAWI>(new WebServiceAWIClient(), new ARM_ARMS.User());
