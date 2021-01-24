    public async Task<string> CreateWorkItemUsingHttpClient(string accesstoken)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json-patch+json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                WorkItemPostData wiPostData = new WorkItemPostData();
                wiPostData.op = "add";
                wiPostData.path = "/fields/System.Title";
                wiPostData.value = "Workitem created through cloud";
                List<WorkItemPostData> wiPostDataArr = new List<WorkItemPostData> { wiPostData };
                string wiPostDataString = JsonConvert.SerializeObject(wiPostDataArr);
                HttpContent wiPostDataContent = new StringContent(wiPostDataString, Encoding.UTF8, "application/json-patch+json");
                string url = "https://dev.azure.com/xyz/abcproject/_apis/wit/workitems/$Bug?api-version=5.0";
                try
                {
                    HttpResponseMessage response = client.PatchAsync(url, wiPostDataContent).Result;
                    try
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            response.EnsureSuccessStatusCode();
                            string responseContent = await response.Content.ReadAsStringAsync();
                            return responseContent;
                        }
                        else
                        {
                            return "Success code returned false";
                        }
                    }
                    catch(Exception ex)
                    {
                        return "One " +ex.Message + " " + ex.StackTrace;
                    }
                }
                catch(Exception ex)
                {
                    return "Two " +ex.Message + " " + ex.StackTrace;
                }
            }
            catch(Exception ex)
            {
                return "Three " +ex.Message + " " + ex.StackTrace;
            }
        }
