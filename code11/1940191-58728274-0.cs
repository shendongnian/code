     using (var client = new HttpClient())
            {
                //here retrieve the token from where you stored it
                string accessToken = "whatever";
                
                client.BaseAddress = new Uri("http://localhost:59983/api/flight");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                var responseTask = client.GetAsync("flight");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<tblFlight>>();
                    readTask.Wait();
                    flights = readTask.Result;
                }
                else
                {
                    flights = Enumerable.Empty<tblFlight>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
