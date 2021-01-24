lSign = string.Format(
                "format={0}&" +
                "location={1}&" +
                "oauth_consumer_key={2}&" +
                "oauth_nonce={3}&" +
                "oauth_signature_method={4}&" +
                "oauth_timestamp={5}&" +
                "oauth_version={6}&" +
                "u={7}",
                cFormat,
                miasto,
                cConsumerKey,
                lNonce,
                cOAuthSignMethod,
                lTimes,
                cOAuthVersion,
                jednostka.ToString().ToLower()
and
url = cURL + "?location=" + Uri.EscapeDataString(miasto) + "&u=" + jednostka.ToString().ToLower() + "&format=" + cFormat;
and
string headerString = _get_auth();
                    WebClient webClient = new WebClient();
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/" + cFormat;
                    webClient.Headers[HttpRequestHeader.Authorization] = headerString;
                    webClient.Headers.Add("X-Yahoo-App-Id", cAppID);
                    byte[] reponse = webClient.DownloadData(url);
                    string lOut = Encoding.ASCII.GetString(reponse);
