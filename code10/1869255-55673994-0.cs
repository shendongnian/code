            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url ="yourUrl" // http://localhost:60291/api/WebForm/Post
                var model=yourObject; //PersonVM  
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(yourObject),Encoding.UTF8, "application/json"));
                
            }
