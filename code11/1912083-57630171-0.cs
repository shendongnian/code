      public async Task<IActionResult> AOFun(RequestValues requestValues)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
                string userID = requestValues.userId;
                string id = requestValues.id;
                string accessToken = requestValues.accessToken;
                string url =
                @"https://companydomain.com/api/api/pl/redirect-url?&vendorSystem=false&action=5&id={{idValue}}&app=ONE"
                .Replace("{{idValue}}", id);
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("userId", userID);
                    client.DefaultRequestHeaders.Add("access_token", accessToken);
                    var responseData = await client.SendAsync(requestMessage);
                    responseData.EnsureSuccessStatusCode();
                    var responseString = await responseData.Content.ReadAsStringAsync();
                    ResponseModel rm = JsonConvert.DeserializeObject<ResponseModel>(responseString);
                    ViewBag.ResponseString = rm.url;
                }
            }
            catch (Exception ex)
            {
                ViewBag.ResponseString = "error: " + ex.Message;
            }
            return View("Index");
        }
