     [WebMethod]
            public static string GetPeoplePickerData()
            {
                try
                {
                    //peoplepickerhelper will get the needed values from the querystring, get data from sharepoint, and return a result in Json format
                    Uri hostWeb = new Uri("http://ramsqlbi:9999/sites/app");
                    var clientContext = TokenHelper.GetS2SClientContextWithWindowsIdentity(hostWeb, HttpContext.Current.Request.LogonUserIdentity);
                    return GetPeoplePickerSearchData(clientContext);
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
            }
