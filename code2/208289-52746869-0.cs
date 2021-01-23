            var client = new WebClient();
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + passWord));
            client.Headers[HttpRequestHeader.Authorization] = $"Basic {credentials}";
            //If you have your data stored in an object serialize it into json to pass to the webclient with Newtonsoft's JsonConvert
            var encodedJson = JsonConvert.SerializeObject(newAccount);
            
            client.Headers.Add($"x-api-key:{ApiKey}");
            client.Headers.Add("Content-Type:application/json");
            try
            {
                var response = client.UploadString($"{apiurl}", encodedJson);
                //if you have a model to deserialize the json into Newtonsoft will help bind the data to the model, this is an extremely useful trick for GET calls when you have a lot of data, you can strongly type a model and dump it into an instance of that class.
                Response response = JsonConvert.DeserializeObject<Response>(response);
