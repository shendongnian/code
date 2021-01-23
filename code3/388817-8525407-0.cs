        // Open the config
        Configuration webConfig = WebConfigurationManager.OpenWebConfiguration("");
        // Retrieve the section
        PagesSection pages = (PagesSection)webConfig.GetSection("system.web/pages");
        // Find the control you are interested in, then load it
        for (int i = 0; i < pages.Controls.Count; i++)
        {
        }
