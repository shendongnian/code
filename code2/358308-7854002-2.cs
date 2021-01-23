         [TestMethod]
            public void LoginEmptyDataTest()
            {
                using (var userServiceClient = new Services.UserServiceClient(
                                            "BasicHttpBinding_IUserService", 
                                            "http://someremotehost/userservice.svc"))
                {
                    var result = userServiceClient.Login("user", "password");
                    
                    // asserts go here
                }
            }
