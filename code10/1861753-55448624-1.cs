    [Authorize]
        [Route("API/Gumtreetoken")]
        public IActionResult GumtreePost(string user, string pasword)
        {
            string atsakas = "";
            string token = "";
            string id = "";
            using (HttpClient client = new HttpClient())
            {
                //parametrai (PARAMS of your call)
                var parameters = new Dictionary<string, string> { { "username", "YOURUSERNAME" }, { "password", "YOURPASSWORD" } };
                //Uzkoduojama URL'ui 
                var encodedContent = new FormUrlEncodedContent(parameters);               
                try
                {
                    //Post http callas.
                    HttpResponseMessage response =  client.PostAsync("https://feed-api.gumtree.com/api/users/login", encodedContent).Result;
                    //nesekmes atveju error..
                    response.EnsureSuccessStatusCode();
                    //responsas to string
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    
                    atsakas = responseBody;
                   
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
                //xml perskaitymui
                XmlDocument doc = new XmlDocument();
                //xml uzpildomas api atsakymu
                doc.LoadXml(@atsakas);
                //iesko TOKEN
                XmlNodeList xmltoken = doc.GetElementsByTagName("user:token");
                //iesko ID
                XmlNodeList xmlid = doc.GetElementsByTagName("user:id");
                token = xmltoken[0].InnerText;
                id = xmlid[0].InnerText;
                atsakas = "ID: " + id + "   Token: " + token;
                
            }
            return Json(atsakas);
        }
