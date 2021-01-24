    [HttpPost]
    public ActionResult ValidateUser(string strUsername, string strPassword)
    {
        string strReturn = "";
        string strDbError = string.Empty;
        strUsername = strUsername.Trim();
        strPassword = strPassword.Trim();
        UserProviderClient ObjUMS = new UserProviderClient();            
        bool result = ObjUMS.AuthenticateUser(strUsername, strPassword, out strDbError);
        Session["isUserAuthenticated"] = result;
        if (result == true)
        {
            Session["isUserOutsideINDomain"] = true;
            Session["OutsideINDomainUsername"] = strUsername;
            //redirect to respective controller
            UMS ObjUMSDATA = new UMS();
            string strUserName = "";
            string strCurrentGroupName = "";
            int intCurrentGroupID = 0;
            strUserName = System.Web.HttpContext.Current.User.Identity.Name.Split('\\')[1];                
            _UMSUserName = strUserName;
            if (!string.IsNullOrEmpty(strUserName))
            {
                List<UMSGroupDetails> lstUMSGroupDetails = null;
                List<UMSLocationDetails> lstUMSLocationDetails = null;
                ObjUMSDATA.GetUMSGroups(strUserName, out strCurrentGroupName, out intCurrentGroupID, out lstUMSLocationDetails, out lstUMSGroupDetails);
                if (strCurrentGroupName != "" && intCurrentGroupID != 0)
                {
                    ViewBag.LoginUserName = strUserName.ToUpper();
                    ViewBag.CurrentGroupName = strCurrentGroupName;
                    ViewBag.CurrentGroupID = intCurrentGroupID;
                    ViewBag.GroupDetails = lstUMSGroupDetails;
                    ViewBag.LocationDetails = lstUMSLocationDetails;
                    TempData["Location"] = lstUMSLocationDetails;
                    TempData["strCurrentGroupName"] = strCurrentGroupName;
                    TempData.Keep();
                    // here you need to return string for success result
                    return Json(strCurrentGroupName);
                }
                else
                {
                    return Json("Error");
                }
            }
        }
        else
        {
            strReturn = "Login UnSuccessful";
        }
        return Json(strReturn);
    }
