        public void ProcessRequest(HttpContext context)
        {
            //NOTE: here you should provide your custom mapping
            //Get compiled type by path
            Type type = BuildManager.GetCompiledType("~/Default.aspx");
            //create instance of the page
            Page page = (Page) Activator.CreateInstance(type);
            //process request
            page.ProcessRequest(context);
        }
