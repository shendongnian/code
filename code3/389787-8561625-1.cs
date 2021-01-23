        public void ProcessRequest(HttpContext context)
        {
            //NOTE: here you should implement your custom mapping
            string yourAspxFile = "~/Default.aspx";
            //Get compiled type by path
            Type type = BuildManager.GetCompiledType(yourAspxFile);
            //create instance of the page
            Page page = (Page) Activator.CreateInstance(type);
            //process request
            page.ProcessRequest(context);
        }
