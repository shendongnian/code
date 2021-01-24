    namespace GoogleSamplecSharpSample.Sheetsv4.Auth
    {
        /// <summary>
    	/// When calling APIs that do not access private user data, you can use simple API keys. These keys are used to authenticate your 
        /// application for accounting purposes. The Google API Console documentation also describes API keys.
        /// https://support.google.com/cloud/answer/6158857
        /// </summary>
        public static class ApiKeyExample
        {
            /// <summary>
            /// Get a valid SheetsService for a public API Key.
            /// </summary>
            /// <param name="apiKey">API key from Google Developer console</param>
    		/// <returns>SheetsService</returns>
            public static SheetsService GetService(string apiKey)
            {
                try
                {
                    if (string.IsNullOrEmpty(apiKey))
                        throw new ArgumentNullException("api Key");
    
                    return new SheetsService(new BaseClientService.Initializer()
                    {
                        ApiKey = apiKey,
                        ApplicationName = string.Format("{0} API key example", System.Diagnostics.Process.GetCurrentProcess().ProcessName),
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to create new Sheets Service", ex);
                }
            }
        }
    }
