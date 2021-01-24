             ApiRequestModel _requestModel = new ApiRequestModel();
            _requestModel.RequestParam1 = "YourValue";
            _requestModel.RequestParam2= "YourValue";
           
	   
	        var jsonContent = JsonConvert.SerializeObject(_requestModel);
            var authKey = "c4b3d4a2-ba24-46f5-9ad7-ccb4e7980da6";
            var qnaMakerURI = "http://10.10.102.109/api/v1/routing/windows/Window1";
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(qnaMakerURI);
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                request.Headers.Add("Authorization", "Basic" + authKey);
                var response = await client.SendAsync(request);
               
                //Check status code and retrive response
                if (response.IsSuccessStatusCode)
                {
                    dynamic objResponse = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    dynamic result_string = await response.Content.ReadAsStringAsync();
                }
            }
				
