     public override async Task<bool> QueryWebSites()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();            
            clientHandler.UseDefaultCredentials = true;
            clientHandler.PreAuthenticate = true;
            
            using (HttpClient client = new HttpClient(clientHandler)) {
                foreach (CRITICAL_APPS app in this.apps) {
                    HttpResponseMessage response = await client.GetAsync(app.URL);                        
                        bool success = response.StatusCode == HttpStatusCode.OK;
                        if (!success) {
                            LOGGER.Debug(app.URL + " failed" + response.StatusCode);
                            LOGGER.Debug(response.ReasonPhrase);
                            LOGGER.Debug(response.RequestMessage);
                            appStatus.Add(new CRITICAL_APPS_STATUS {APP_ID = app.ID, INITIAL_DETECTION =DateTime.Now, ID = 77 });
                        } else {
                            LOGGER.Debug(app.URL + " succeeded");
                        }                   
                }
            }
            clientHandler.Dispose();
            return true;
        }       
