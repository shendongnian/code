        async static Task<string> GetData(string guid, StringContent json, string token)
        {
            string url = "https://api.elliemae.com/encompass/v1/loans/" + guid + "/fieldReader";
            Console.WriteLine("{0} has started .....", guid);
            using (HttpResponseMessage response = await ApiHelper.Create(token).PostAsync(url, json))
            {
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("{0} has returned response....", guid);
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine(response.ReasonPhrase);
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
