// Sync
var accessToken = _client.GetAccessToken(); //Store this token for "remember me" function
// Async
_client.GetAccessTokenAsync((accessToken) =>
    {
        //Store this token for "remember me" function
    },
    (error) =>
    {
        //Handle error
    });</code></pre> 
Note that var accessToken is really a DropNet.Models.UserLogin object.  That object contains:
        public string Token { get; set; }
        public string Secret { get; set; }
