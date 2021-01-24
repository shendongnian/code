        public string ApiToken
        {
            get
            {
                if (!string.IsNullOrEmpty(apitoken))
                    return apitoken;
                apitoken = Browser.ReadStorage("apitoken");
                return apitoken;
            }
            set
            {
                Browser.WriteStorage("apitoken", value);
            }
        }
