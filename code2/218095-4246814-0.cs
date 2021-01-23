    String username = User.Identity.Name;
                String pageRequested = ((HttpApplication)sender).Request.Path;
    
                error = Server.GetLastError().GetBaseException();
                
                String message = "ERROR MESSAGE: " + error.Message +
                                    "\nINNER EXCEPTION: " + error.InnerException +
                                    "\nSOURCE: " + error.Source +
                                    "\nFORM: " + Request.Form.ToString() +
                                    "\nQUERYSTRING: " + Request.QueryString.ToString() +
                                    "\nTARGETSITE: " + error.TargetSite +
                                    "\nSTACKTRACE: " + error.StackTrace +
                                    "\nNCLWEB USERNAME: " + username +
                                    "\nDATESTAMP: " + DateTime.Now;
                    
                System.Diagnostics.EventLog.WriteEntry("NCLWeb", message, System.Diagnostics.EventLogEntryType.Error);
