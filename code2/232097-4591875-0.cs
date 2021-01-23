    string Response = Utilities.HttpUtility.Fetch("https://graph.facebook.com/me?access_token=" + AccessToken, "GET", string.Empty);
                using (System.IO.MemoryStream oStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(Response)))
                {
                    oStream.Position = 0;
                    return (Models.FacebookUser)new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Models.FacebookUser)).ReadObject(oStream);
                }
