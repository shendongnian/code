    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    namespace Katana.Sandbox.WebServer
    {
        internal class GoogleUserInfoRemapper : DelegatingHandler
        {
            public GoogleUserInfoRemapper(HttpMessageHandler innerHandler) : base(innerHandler) { }
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var response = await base.SendAsync(request, cancellationToken);
                if (!request.RequestUri.AbsoluteUri.Equals("https://www.googleapis.com/oauth2/v2/userinfo"))
                {
                    return response;
                }
                response.EnsureSuccessStatusCode();
                var text = await response.Content.ReadAsStringAsync();
                JObject user = JObject.Parse(text);
                JObject legacyFormat = new JObject();
                JToken token;
                if (user.TryGetValue("id", out token))
                {
                    legacyFormat["id"] = token;
                }
                if (user.TryGetValue("name", out token))
                {
                    legacyFormat["displayName"] = token;
                }
                JToken given, family;
                if (user.TryGetValue("given_name", out given) && user.TryGetValue("family_name", out family))
                {
                    var name = new JObject();
                    name["givenName"] = given;
                    name["familyName"] = family;
                    legacyFormat["name"] = name;
                }
                if (user.TryGetValue("link", out token))
                {
                    legacyFormat["url"] = token;
                }
                if (user.TryGetValue("email", out token))
                {
                    var email = new JObject();
                    email["value"] = token;
                    legacyFormat["emails"] = new JArray(email);
                }
                if (user.TryGetValue("picture", out token))
                {
                    var image = new JObject();
                    image["url"] = token;
                    legacyFormat["image"] = image;
                }
                text = legacyFormat.ToString();
                response.Content = new StringContent(text);
                return response;
            }
        }
    }
