    public Model User
    {
        private string searchText
        {
            get { return SessionHelper.Get<string>("searchText"); }
            set { SessionHelper.Add("searchText", value); }
        }
    }
