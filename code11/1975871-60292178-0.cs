            var originKey =
                Request.Headers.AllKeys.FirstOrDefault(
                    a => a.Equals("origin", StringComparison.InvariantCultureIgnoreCase));
            
            if (originKey != null && Request.HttpMethod == "OPTIONS"))
            {
                Response.Headers.Add("Access-Control-Allow-Origin", Request.Headers[originKey]);
                Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUSH, DELETE, OPTIONS");
                Response.Headers.Add("Access-Control-Allow-Headers",
                    "Authorization, Content-Type, Access-Control-Allow-Headers, X-Requested-With, Access-Control-Allow-Method, Accept");
                Response.Flush();
                Response.End();
                return;
            }
