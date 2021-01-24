      public async Task<IActionResult> OnPostGenerateWebName(string returnUrl = null)
        {
            CreateWebName();
            // all  done
            return Page();
        }
        private void CreateWebName()
        {
            //generate a web name for this business
            if (Business.BusinessName.Length > 0)
            {
                var WebName = Business.BusinessName;
                // remove all special characters, only keep 0-9,a-z,A-Z
                WebName = Regex.Replace(Business.BusinessName, "[^0-9a-zA-Z]+", "");
                // set the new web name
                ModelState.Clear();
                Business.BusinessWebName = WebName;
                
            }
