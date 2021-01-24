    using (HttpClient client = new HttpClient(clientHandler)) {                
                foreach (CRITICAL_APPS app in this.apps) {
                    using (HttpResponseMessage response = await client.GetAsync(app.URL))
                    {
                        bool success = response.StatusCode == HttpStatusCode.OK;
                        if (success) {
                            LOGGER.Debug(app.URL + " succeeded");
                        } else {
                            if (response.StatusCode == HttpStatusCode.InternalServerError)
                            {                               
                                // Try to read response, log error etc.
                                var errorxml = await response.Content.ReadAsStringAsync();
                                LOGGER.Debug(app.URL + " failed" + errorxml);                                
                            }
                            appStatus.Add(new CRITICAL_APPS_STATUS { APP_ID = app.ID, INITIAL_DETECTION = DateTime.Now, ID = 77 });
                        }
                    }
                }
            }
            clientHandler.Dispose();
