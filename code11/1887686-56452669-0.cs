    async void Auth()
    {
        try
        {
            string authenticationKey = null;
            while(string.IsNullOrEmpty(authenticationKey))
            {
                Console.WriteLine("Verify authentication");
                Console.WriteLine("Enter your 6 digit code: ");
                authenticationKey = Console.ReadLine();
                if (string.IsNullOrEmpty(authenticationKey))
                {
                    Console.WriteLine("Auth key is empty");
                    continue;
                }
                        
                if (!await IsAuthenticated(authenticationKey))
                {
                    Console.WriteLine("Failed to validate credentials.");
                    authenticationKey = null;
                    continue;
                }
                break;
            }
            Console.WriteLine("Successfully validated credentials, starting program...");
            Setup();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error raised closing application: {ex.Message}");
            Thread.Sleep(5000);
            Environment.Exit(0);
        }
    }
    async Task<bool> IsAuthenticated(string key)
    {
        if (string.IsNullOrEmpty(key))
            return false;
        using (HttpClient client = new HttpClient())
        using (HttpResponseMessage response = await client.GetAsync("http://www.authentication.com/example"))
        using (HttpContent content = response.Content)
        {
            string result = await content.ReadAsStringAsync();
            return result.Contains(key);
        }
    }
