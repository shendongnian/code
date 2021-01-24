                         {
                        // Enables the application to validate the security stamp when the user logs in.
                        // This is a security feature which is used when you change a password or add an external login to your account.  
                        OnValidateIdentity = SecurityStampValidator
                        .OnValidateIdentity<ApplicationUserManager, ApplicationUser, int>
                        (
                            validateInterval: TimeSpan.FromMinutes(30),
                            regenerateIdentityCallback: (manager, user) => 
                            user.GenerateUserIdentityAsync(manager), 
                            getUserIdCallback:(id) => Int32.Parse(id.GetUserId(), 
                            CultureInfo.InvariantCulture)
                            //getUserIdCallback:(id) => (Int32.Parse(id.GetUserId()))
                        )
                    }
