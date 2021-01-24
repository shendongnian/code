    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Admin.Directory.directory_v1;
    using Google.Apis.Admin.Directory.directory_v1.Data;
    using Google.Apis.Services;
    using System;
    using System.IO;
    
    // dotnet add package Google.Apis.Admin.Directory.directory_v1
    // Tested with version 1.39.0.1505
    
    // Google.Apis.Admin.Directory.directory_v1.Data.User
    // https://developers.google.com/resources/api-libraries/documentation/admin/directory_v1/csharp/latest/classGoogle_1_1Apis_1_1Admin_1_1Directory_1_1directory__v1_1_1Data_1_1User.html
    
    namespace Example
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			// Service Account with Domain-Wide delegation
    			var sa_file = "service_account.json";
    
    			// G Suite User to impersonate
    			var user_email = "admin@example.com";
    
    			// G Suite User to get information about
    			var gs_email = "user1@example.com";
    
    			// Scopes
    			var scopes = "https://www.googleapis.com/auth/admin.directory.user";
    
    			var credential = GoogleCredential.FromFile(sa_file)
    						.CreateScoped(scopes)
    						.CreateWithUser(user_email);
    
    			// Create Directory API service.
    			var service = new DirectoryService(new BaseClientService.Initializer()
    			{
    				HttpClientInitializer = credential
    			});
    
    			try {
    				var request = service.Users.Get(gs_email);
    
    				var result = request.Execute();
    
    				Console.WriteLine("Full Name: {0}", result.Name.FullName);
    				Console.WriteLine("Email:     {0}", result.PrimaryEmail);
    				Console.WriteLine("ID:        {0}", result.Id);
    				Console.WriteLine("Is Admin:  {0}", result.IsAdmin);
    			} catch {
    				Console.WriteLine("User not found.");
    			}
    		}
    	}
    }
