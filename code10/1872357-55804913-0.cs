public void Awake()
{
        // Init Facebook SDK
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK Configuration
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
             // Already initialized, signal an app activation App Event
             FB.ActivateApp();
        }
}
private void InitCallback() {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
} 
private void AuthCallback(ILoginResult result)
{
        if (FB.IsLoggedIn)
        {
            // Here is the region where u r loggged in from facebook acccount
            // Just put your Logic Here
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
        }
        else
        {
            Debug.Log("Facebook User cancelled login");
        }
}
and here is what you need to call when u press a button,<br>
public void LoginWithFaceBook()
{
        var perms = new List<string>() { "public_profile", "email" };
        FB.LogInWithReadPermissions(perms, AuthCallback);
}
also use this when u logout from your application 
public void FacebookLogout()
{
        if (FB.IsLoggedIn)
        {
            FB.LogOut();
        }
}
