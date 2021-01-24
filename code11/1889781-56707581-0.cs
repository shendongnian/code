        [HttpGet, Route("values")]
        public async Task<string> Post()
        {
            
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.elliemae.com/oauth2/");
                var parameters = new Dictionary<string, string>()
                {
                    {"grant_type", "password"}, //Gran_type Identified here
                    {"username", "admin@encompass:BE11200822"},
                    {"password", "Shmm*****"},
                    {"client_id", "gpq4sdh"},
                    {"client_secret", "dcZ42Ps0lyU0XRgpDyg0yXxxXVm9@A5Z4ICK3NUN&DgzR7G2tCOW6VC#HVoZPBwU"},
                    {"scope", "lp"}
                };
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "v1/token")
                {
                    Content = new FormUrlEncodedContent(parameters)
                };
                HttpResponseMessage response = await client.SendAsync(request);
                string resulted = await response.Content.ReadAsStringAsync();
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(resulted);
                string x  = System.Convert.ToBase64String(plainTextBytes);
                await Get(x);
                return resulted;
            }
       
        }
