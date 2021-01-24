        public async Task PostFailureMessage([ActivityTrigger] string input)
        {   // I got the error on this line
            string uri;
            // ...
            uri = input["failureURI"].ToString(); // trying to access as a JObject here
            // ...
        }
