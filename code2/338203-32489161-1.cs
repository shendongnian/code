        public static Uri GetLoginUrl(bool rerequestPermissions)
        {
            var client = new FacebookClient();
            dynamic para = new ExpandoObject();
            para.client_id = Settings.AppId;
            para.redirect_uri = Settings.LoginRedirUrl;
            para.response_type = Settings.ResponseType;
            para.scope = Settings.Scope; // Includes user_managed_groups
            // true if you've detected that one or more permissions have been denied
            // or revoked. It'll promt the user to grant the permissions again as when they
            // first used your app.
            if (rerequestPermissions)
                para.auth_type = "rerequest";
            return client.GetLoginUrl(para);
        }
