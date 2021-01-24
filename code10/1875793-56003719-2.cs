    public Users GetDirService()//UserList with DirectoryService
        {
            string Admin_Email = "yoursuperadminemail";
            string domain = "yourdomain.com";
            try
            {
                var certificate = new X509Certificate2(@"yourkeyfile.p12", "notasecret", X509KeyStorageFlags.Exportable);
                ServiceAccountCredential credentialUsers = new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(serviceAccountEmail)
                {
                    Scopes = new[] { DirectoryService.Scope.AdminDirectoryUser },
                    User = Admin_Email,
                }.FromCertificate(certificate));
                var serviceUsers = new DirectoryService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credentialUsers,
                    ApplicationName = AppName,
                });
                var listReq = serviceUsers.Users.List();
                listReq.Domain = domain;
                Users users = listReq.Execute();
                return users;
            }
            catch (Exception ex)
            {
                MessageBox.Show("your mail address must be super admin authorized.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }
    
