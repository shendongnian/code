    public string Mask
                {
                    get
                    {
                        String tblName = (String)ViewState["Mask"];
                        return (Mask ?? String.Empty); // This is causing your stack overflow...
                    }
                }
