c#
    public static async Task Login()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://testing-ground.scraping.pro/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                
                var username = "admin";
                var password = "12345";
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("usr", username),
                    new KeyValuePair<string, string>("pwd", password),
                });
                
                HttpResponseMessage responseMessage = await client.PostAsync("/login?mode=login", formContent);
                
                var response = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(response);
            }
        }
I realised that requestURL should be `/login?mode=login` insead of `/login`
I changed also DefaultRequestHeaders to `application/x-www-form-urlencoded` after inspecting in fiddler the headers.
