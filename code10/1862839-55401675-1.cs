        public async Task<T> GetJsonAsync<T>(string uri)
        {
                this.InProgress = true;
                var result = await http.GetJsonAsync<ServerResult<T>>(uri, this.ApiToken);
                this.InProgress = false;
                if (!result.Success)
                {
                    BlazorExtensions.Browser.Alert($"Error: {result.ErrorMessage}");
                    return default(T);
                }
                return result.ValueObject;
            
        }
