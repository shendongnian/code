         private static readonly HttpClient client = new HttpClient();
         // HttpGet
         public static async Task<object> GetAsync(this string url, object parameter = null, Type castToType = null)
            {
                if (parameter is IDictionary)
                {
                    if (parameter != null)
                    {
                        url += "?" + string.Join("&", (parameter as Dictionary<string, object>).Select(x => $"{x.Key}={x.Value ?? ""}"));
                    }
                }
                else
                {
                    var props = parameter?.GetType().GetProperties();
                    if (props != null)
                        url += "?" + string.Join("&", props.Select(x => $"{x.Name}={x.GetValue(parameter)}"));
                }
    
                var responseString = await client.GetStringAsync(new Uri(url));
                if (castToType != null)
                {
                    if (!string.IsNullOrEmpty(responseString))
                        return JsonConvert.DeserializeObject(responseString, castToType);
                }
    
                return null;
            }
       // HTTPPost
       public static async Task<object> PostAsync(this string url, object parameter, Type castToType = null)
        {
            if (parameter == null)
                throw new Exception("POST operation need a parameters");
            var values = new Dictionary<string, string>();
            if (parameter is Dictionary<string, object>)
                values = (parameter as Dictionary<string, object>).ToDictionary(x => x.Key, x => x.Value?.ToString());
            else
            {
                values = parameter.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(parameter)?.ToString());
            }
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(url, content);
            var contents = await response.Content.ReadAsStringAsync();
            if (castToType != null && !string.IsNullOrEmpty(contents))
                return JsonConvert.DeserializeObject(contents, castToType);
            return null;
        }
