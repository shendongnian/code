    public static async Task<string> TestGravApi(float lat, float lon, float eht)
        {
            GravityObjResult gResult = new GravityObjResult();
            
       ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
       | SecurityProtocolType.Tls11
       | SecurityProtocolType.Tls12
       | SecurityProtocolType.Ssl3;
            using (var httpClient = new HttpClient())
            {
                string url = String.Format("https://{my-url-here}/api/gravd/gp?lat={0}&lon={1}&eht={2}", lat, lon, eht);
                var json = await httpClient.GetStringAsync(url);
                //sends from object to string json
                //string output = JsonConvert.SerializeObject(product);
                if (json != null)
                {
                    gResult = JsonConvert.DeserializeObject<GravityObjResult>(json);
                    // Now parse with JSON.Net
                    return gResult.predictedGravity;
                }
            }
            return String.Empty;
        }
