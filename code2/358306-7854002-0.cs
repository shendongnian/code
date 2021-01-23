        [TestMethod]
        public void LoginEmptyDataTest()
        {
            using (var userServiceClient = new Services.UserServiceClient())
            {
                var result = userServiceClient.Login("user", "password");
                
                // asserts go here
            }
        }
