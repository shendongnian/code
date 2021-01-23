            if (!this.IsPostBack)
            {
                incrementPageState();
                Response.Write("Page Data " + SomeData["myKey"] + "<br />");    
            }
        private void incrementPageState()
        {
            // Page Data Usage
            if (SomeData.ContainsKey("myKey"))
            {
                SomeData["myKey"] = SomeData["myKey"] + 1;
            }
            else
            {
                SomeData["myKey"] = 1;
            }
        }
