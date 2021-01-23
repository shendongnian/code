        protected void Application_Start()
        {
            string[] languages = HttpContext.Current.Request.UserLanguages;
            if (languages != null && languages.Length > 0)
            {
                string language = languages[0].ToLowerInvariant().Trim();
                CultureInfo currentCulture = CultureInfo.CreateSpecificCulture(language);
                if (currentCulture != null)
                {
                    RegionInfo regionInfo = new RegionInfo(currentCulture.LCID);
                }
            }
            switch (RegionInfo.CurrentRegion.Name)
            {
                case "...":
                    Session["ConnectionString"] = "...";
                    break;
            }
        }
        protected void Application_End()
        {
            Session.Clear();
        }
