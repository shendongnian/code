            /// <summary>
            /// Calls for a reset of caches on one or more user sites serving reports. 
            /// Allows for multiple urls to be processed; configure the reset targets
            /// using AppSettings["UserCacheResetUrl"], delimited with pipes if there
            /// are multiple sites. 
            /// </summary>
            public static void ClearAllUserCaches()
            {
                //
                // clear local user caches
                ClearUserCaches();
    
                //
                // clear out of process user caches
               
                string[] urls = AppSettings.UserServers;
    
                for( int i = 0; i < urls.Length; i++ )
                {
                    string url = urls[i] + AppSettings.UserCacheResetPath + "&sharedPassword=" + AppSettings.SharedPassword;
    
                    WebRequest request = null;
                    HttpWebResponse response = null;
    
                    try
                    {
                        request = WebRequest.Create( url );
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch( WebException ex )
                    {
                        Log.LogException( ex );
                    }
                    finally
                    {
                        request = null;
                    }
    
                    if( response == null || response.StatusCode != HttpStatusCode.OK )
                    {
                        if( response != null )
                        {
                            response.Close();
                            response = null;
                        }
                    }
                }
            }
