        private string GetValue
        {
            get
            {
                string result = string.empty;
                if (ViewState["someID"] != null)
                {
                    result = (string)ViewState["someID"];
                }
                return result;
            }
            set
            {
                ViewState["someID"] = value;
            }
        }
