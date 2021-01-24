     var userApi = httpClientFactory.CreateClient("UserApi");
                var request = new HttpRequestMessage(HttpMethod.Post, "systemuser/login");
                request.Content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");
    
                var response = await userApi.SendAsync(request);
    
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var body = await response.Content.ReadAsAsync<LoginResponse>();
                    return Ok(body);
                }
                return StatusCode((int)response.StatusCode);
