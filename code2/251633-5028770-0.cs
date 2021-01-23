        protected override void InitializeCulture()
        {
            String selectedLanguage = Common.SessionManager.Language;
            if (Request.Form.ContainsKey(myLanguageDropDown.ClientID)
                selectedLanguage = Request.Form[myLanguageDropDown.ClientID];
            if (selectedLanguage == "")
            {
            ...
