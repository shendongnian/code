            Dictionary<string, object> position = new System.Collections.Generic.Dictionary<string, object>();
            position.Add("latitude", 25.04098367f);
            position.Add("longitude", 121.54597771f);
            
            Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
            parameters.Add("access_token", _accessToken);
            parameters.Add("message", "自行開發應用程式打卡");
            parameters.Add("place", "236679649740148");
            parameters.Add("coordinates", position);
