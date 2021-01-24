c-sharp
    [Route("install")]
        public async Task<IHttpActionResult> InstallProduct()
        {
            Log("milestone1");
            await Install();
            Log("milestone6");
        }
        private async Task Install()
        {
            await MyClass.Register();
            Log("milestone5");
        }
        private static async Task Register()
        {
            Log("milestone2");
            using (var handler = new HttpClientHandler())
            {
                using (var client = new HttpClient(handler))
                {
                    var method = "http://BaseUrlOfWebsite#2/api/applications";
                    using (MultipartFormDataContent form = new MultipartFormDataContent())
                    {
                        //make POST API call into website # 2
                        var response = await client.PostAsync(method, form);
                        Log("milestone3");
                    }
                }
            }
            Log("milestone4");
        }
