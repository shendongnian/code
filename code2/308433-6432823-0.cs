    public List<Cookie> Cookies {
        get {
            return Settings.Default.Cookies;
        }
        set {
            Settings.Default.Cookies = value;
            Settings.Default.Save();
        }
    }
