    public class UserStillActiveAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            int sessionTimeoutInMinutes = int.Parse(ConfigurationManager.AppSettings["SESSION_TIMEOUT"].ToString());
            int maxContiguousAutoSaves = int.Parse(ConfigurationManager.AppSettings["MAX_CONSEC_SAVES"].ToString());
            int autoSaveIntervalInMinutes = int.Parse(ConfigurationManager.AppSettings["AUTO_SAVE_INTERVAL"].ToString());
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            HttpContext currentSession = HttpContext.Current;      
            LogAssociateGoalsSessionStatus(filterContext.HttpContext, actionName);
            if (actionName.ToLower().Contains("autosave"))
            {
                int autoSaveCount = GetContigousAutoSaves(filterContext.HttpContext);
                if (autoSaveCount == maxContiguousAutoSaves)
                {
                    var result = new RedirectResult("~/Account.aspx/LogOff");
                    if (result != null && filterContext.HttpContext.Request.IsAjaxRequest())
                    {
						//Value checked on Logon.aspx page and message displayed if not null
                        filterContext.Controller.TempData.Add(PersistenceKeys.SessionTimeOutMessage,
                            StaticData.MessageSessionExpiredWorkStillSaved);
							string destinationUrl = UrlHelper.GenerateContentUrl(
                                                    result.Url,
                                                    filterContext.HttpContext);
                        filterContext.Result = new JavaScriptResult()
                        {
                            Script = "window.location='" + destinationUrl + "';"
                        };
                    }
                }
                else
                {
                    RefreshContiguousAutoSaves(filterContext.HttpContext, autoSaveCount + 1);
                }
            }
            else
            {
                RefreshContiguousAutoSaves(filterContext.HttpContext, 1);
            }
        }
        private int GetContigousAutoSaves(HttpContextBase context)
        {
            Object o = context.Session[PersistenceKeys.ContiguousAutoUpdateCount];
            int contiguousAutoSaves = 1;
            if (o != null && int.TryParse(o.ToString(), out contiguousAutoSaves))
            {
                return contiguousAutoSaves;
            }
            else
            {
                return 1;
            }
        }
        private void RefreshContiguousAutoSaves(HttpContextBase context,
                                                int autoSavecount)
        {
            context.Session.Remove(PersistenceKeys.ContiguousAutoUpdateCount);
            context.Session.Add(PersistenceKeys.ContiguousAutoUpdateCount,
                                        autoSavecount);
        }
        private void LogAssociateGoalsSessionStatus(HttpContextBase filterContext, string actionName)
        {
            AssociateGoals ag = (AssociateGoals)filterContext.Session[(PersistenceKeys.SelectedAssociateGoals)];
            bool assocGoalsIsNull = false;
            bool assocGoalsInformationIsNull = false;
            if (ag == null)
            {
                assocGoalsIsNull = true;
                assocGoalsInformationIsNull = true;
            }
            else if (ag != null && ag.AssociateInformation == null)
                assocGoalsInformationIsNull = true;
        }
    }
