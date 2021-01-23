        public void ProcessRequest(HttpContext context)
        {
            string name = context.Request.QueryString.ToString();
            string output = string.Empty;
            name = db.Names.FirstOrDefault(x => x.Name == name);
            if (name != null && name.Name != null)
            {
                output = "{available:true}";
            }
            else
            {
                output = "{available:false}";
            }
            context.Response.ContentType = "application/json";
            context.Response.Write(output);
        }
