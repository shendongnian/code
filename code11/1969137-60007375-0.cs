    using FirebaseAdmin;
    using Google.Apis.Auth.OAuth2;
    public class FirebaseConfiguration
    {
        public void Initialize()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.GetApplicationDefault(),
            });
        }
    }
