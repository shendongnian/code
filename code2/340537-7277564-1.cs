     /// <summary>
        /// Lazy initialized and persisted in session
        /// </summary>
        public SomePageViewModel ViewModel
        {
            get
            {
                if (Session["SomePageViewModel"] == null)
                {
                    Session.Add("SomePageViewModel", new SomePageViewModel());
                }
                return Session["SomePageViewModel"] as SomePageViewModel;
            }
            set
            {
                if (value == null)
                {
                    if (Session["SomePageViewModel"] != null)
                    {
                        Session.Remove("SomePageViewModel");
                    }
                }
                else
                {
                    Session["SomePageViewModel"] = value;
                }
            }
        }
