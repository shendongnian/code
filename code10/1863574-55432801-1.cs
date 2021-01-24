        public void OnGet()
        {
            var s = HttpContext.Session.GetString("MyData");
            if (!String.IsNullOrWhiteSpace(s))
            {
                
            }
            else
            {
                this.HttpContext.Session.SetString("MyData", "Test Data Here");
            }            
        }
        public void OnPost()
        {
            var s = HttpContext.Session.GetString("MyData");
            if (!String.IsNullOrWhiteSpace(s))
            {
            }
            else
            {
                this.HttpContext.Session.SetString("MyData", "Test Data Here");
            }
        }
