    browser.IsBrowserInitializedChanged += OnIsBrowserInitializedChanged;
    private void OnIsBrowserInitializedChanged(object sender, EventArgs e)
    {
      InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("el-gr"));
    }
