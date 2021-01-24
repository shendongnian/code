        public async Task<IActionResult> Index()
        {
            var model = new SimpleRequest
                                {
                                    UserId = "Sample",
                                    RequestType = RequestType.Simple,
                                    Timestamp = DateTime.Now,
                                    Test = true,
                                    ExtraData = new ExtraData
                                    {
                                        FirstName = "John",
                                        LastName = "Smith",
                                        Id = 1234,
                                        Nr = 1,
                                        RDate = DateTime.Now.AddDays(-2)
                                    }
                                };
            var keyValueContent = model.ToKeyValue();
            keyValueContent.Add("param1", "YES");
            var formUrlEncodedContent = new FormUrlEncodedContent(keyValueContent);
            var urlEncodedString = await formUrlEncodedContent.ReadAsStringAsync();
            var client = new RestClient("http://localhost:51420/api/values/Put");
            var request = new RestRequest(Method.PUT);
            request.AddParameter("application/x-www-form-urlencoded", urlEncodedString, ParameterType.RequestBody);
            var response = client.Execute(request);
        }
