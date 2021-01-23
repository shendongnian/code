                var facebookClient = new FacebookClient(FbConf.testimonialsAppId, FbConf.testimonialsAppSecret);
    
                IDictionary<string, string> parameters = new Dictionary<string, string>();
    
                parameters.Add("message","message on the wall"));
                parameters.Add("created_time", DateTime.Now.ToString());
    
                dynamic result = facebookClient.Post(string.Format("{0}/feed", FbConf.testimonialsAppId), parameters);
                var id = result.id;
