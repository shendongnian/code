    protected void Page_Load(object sender, EventArgs e)
        {
            SetActiveNavLink();
        }
        private void SetActiveNavLink()
        {
            if (HttpContext.Current.CurrentHandler.ToString().ToLower().Contains("default"))
            {
                home.Attributes.Add("class", "active");
            }
            if (HttpContext.Current.CurrentHandler.ToString().ToLower().Contains("about"))
            {
                about.Attributes.Add("class", "active");
            }
            if (HttpContext.Current.CurrentHandler.ToString().ToLower().Contains("experience"))
            {
                experience.Attributes.Add("class", "active");
            }
            if (HttpContext.Current.CurrentHandler.ToString().ToLower().Contains("capabilities"))
            {
                capabilities.Attributes.Add("class", "active");
            }
            if (HttpContext.Current.CurrentHandler.ToString().ToLower().Contains("benefits"))
            {
                benefits.Attributes.Add("class", "active");
            }
        }
