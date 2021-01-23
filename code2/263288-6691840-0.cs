        public static void ProcessIEURLs()
        {
            string sURL;
            try
            {
                DdeClient oDde = new DdeClient("IExplore", "WWW_GetWindowInfo");
           
                try
                {
                    oDde.Connect();
                    sURL = oDde.Request("1", int.MaxValue);
                    oDde.Disconnect();
                    bool bVisited = false;
                    if ( oVisitedURLList != null && oVisitedURLList.Count > 0 )
                    {
                        bVisited = FindURL(sURL, oVisitedURLList);
                    }
                    if ( !bVisited )
                    {
                        oVisitedURLList.Add(sURL);
                    }
                }
                catch ( Exception ex )
                {
                    throw ex;
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
