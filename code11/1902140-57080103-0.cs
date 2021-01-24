    [Given(@"a user is logged in with (key:.*) and has password (key:.*) and username John")]
            public void GivenAUserIsLoggedInWithKeyTestkeyAndHasPasswordKeyTestpasswordAndUsernameJohn(string username, string password)
            {
                var user = username;
                var pass = password;
    
                Console.Write("username: {0} and password: {1} ", user, pass );
            }
    [StepArgumentTransformation(@"key:(.*)")]
            public string ValueForKey(string value)
            {
                return value;
            }
