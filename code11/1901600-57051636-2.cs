        try
        {
            string username = "adm", password = "123456";
            string payload = "http://192.168.2.1/apply.cgi/?_ajax=1&_web_cmd=%21%0Aio%20output%201%20on%0A";
            HttpClient client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            HttpResponseMessage response = await client.GetAsync(payload);
            HttpContent content = response.Content;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
            }
           
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("Auth error");
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
   
