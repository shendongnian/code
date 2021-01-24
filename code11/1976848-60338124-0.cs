    public class Tokenization
    {
    	private static Tokenization Instance = new Tokenization();
        private AuthToken AuthToken = null;
    
    	private Tokenization(){}
    
        private void GetToken(string strBearTokenURL, string strAppid, string strAppkey)
        {
            RestClient tokenClinet = new RestClient(strBearTokenURL);
            tokenClinet.AddDefaultHeader("App_ID", strAppid);
            tokenClinet.AddDefaultHeader("App_Key", strAppkey);
            tokenClinet.AddDefaultHeader("apiVersion", "2");
            AuthToken = tokenClinet.Post<AuthToken>(new RestRequest()).Data;
        }
    
        private bool IsTokenExpired(string strBearTokenURL, string strAppid, string strAppkey)
        {    
            if (AuthToken == null) GetToken( strBearTokenURL, strAppid, strAppkey);
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(AuthToken.expires_on).ToLocalTime();
            return dtDateTime <= DateTime.Now;
        }
    
    
        public RestClient RestClientWithAuth(string strBearTokenURL, string strAppid, string strAppkey)
        {
            try
            {
                RestClient clinet = new RestClient();
                if (IsTokenExpired(strBearTokenURL, strAppid, strAppkey)) GetToken(strBearTokenURL, strAppid, strAppkey);
                clinet.AddDefaultHeader("Authorization", "Bearer " + AuthToken.access_token);
                return clinet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
    
    
    
        public string Tokenize(string tokenData, string tokenGroup, string tokenTemplate, string tokenizeServiceURL, string bearerTokenURL, string app_ID, string app_Key)
        {
            try
            {                    
                var request = new RestRequest(tokenizeServiceURL, Method.POST);
                request.RequestFormat = DataFormat.Json;
                List<TokenProfile> payLoad = new List<TokenProfile>();               
    
                payLoad.Add(new TokenProfile() { tokengroup = tokenGroup, data= tokenData, tokentemplate = tokenTemplate });                
    
                request.AddJsonBody(payLoad);
                // execute the request
                IRestResponse<List<TokenResponse>> response = RestClientWithAuth(bearerTokenURL, app_ID, app_Key).Execute<List<TokenResponse>>(request);
                var responsestatus = response.ResponseStatus;
                return response.Data.Select(t => t.token).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    
        public string Detokenize(string deTokenData, string tokenGroup, string tokenTemplate, string detokenizeServiceURL, string bearerTokenURL, string app_ID, string app_KeyPay)
        {
            try
            {
                var request = new RestRequest(detokenizeServiceURL, Method.POST);
                request.RequestFormat = DataFormat.Json;
                List<DeTokenProfile> payLoad = new List<DeTokenProfile>();                
                payLoad.Add(new DeTokenProfile() { tokengroup = tokenGroup, token = deTokenData, tokentemplate = tokenTemplate });
                request.AddJsonBody(payLoad);
                IRestResponse<List<DeTokenResponse>> response = RestClientWithAuth(bearerTokenURL, app_ID, app_KeyPay).Execute<List<DeTokenResponse>>(request);
                var responsestatus = response.ResponseStatus;
                return response.Data.Select(t => t.data).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
