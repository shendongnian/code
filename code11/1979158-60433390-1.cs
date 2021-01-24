                // create user session data and provide login details
                var userSession = new UserSessionData
                {
                    UserName = "username",
                    Password =  "password"
                };
                // create new InstaApi instance using Builder
                _instaApi = InstaApiBuilder.CreateBuilder()
                    .SetUser(userSession)
                    .UseLogger(new DebugLogger(LogLevel.Exceptions)) // use logger for requests and debug messages
                    .SetRequestDelay(TimeSpan.FromSeconds(2))
                    .Build();
                const string stateFile = "state.bin";
                try
                {
                    if (File.Exists(stateFile))
                    {
                        Console.WriteLine("Loading state from file");
                        Stream fs = File.OpenRead(stateFile);
                        fs.Seek(0, SeekOrigin.Begin);
                        _instaApi.LoadStateDataFromStream(fs);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                if (!_instaApi.IsUserAuthenticated)
                {
                    // login
                    Console.WriteLine($"Logging in as {userSession.UserName}");
                    var logInResult = await _instaApi.LoginAsync();
                    if (!logInResult.Succeeded)
                    {
                        Console.WriteLine($"Unable to login: {logInResult.Info.Message}");
                        return false;
                    }
                }
                var state = _instaApi.GetStateDataAsStream();
                using (var fileStream = File.Create(stateFile))
                {
                    state.Seek(0, SeekOrigin.Begin);
                    state.CopyTo(fileStream);
                }
