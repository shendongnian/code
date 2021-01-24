    private static Lazy<HttpClient> client = new Lazy<HttpClient>();
    protected async Task<Object> GetValue(string metodo = "", string parametros = "") {
        try {
            _urlBase = new Uri(GetStringConnectionParameters(metodo) + parametros);                        
            using (HttpResponseMessage response = await client.Value.GetAsync( _urlBase)) {               
                if (response.IsSuccessStatusCode) {
                    Stream content = await response.Content.ReadAsStreamAsync();
                    return DeserializeJsonFromStream<Object>(content);
                }
            }
        } catch (Exception e) {
            LogUtil.WriteLog(e);
        }    
        return null;
    }
