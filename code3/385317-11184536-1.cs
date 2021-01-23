    void btnSubmit_Click(object sender, EventArgs e)
    {
     //ctrlpplPicker is object of PeopleEditor
     string[] userarray = ctrlpplPicker.CommaSeparatedAccounts.ToString().Split(',');;
     SPFieldUserValueCollection usercollection = new SPFieldUserValueCollection();
     for (int i = 0; i < userarray.Length; i++)
     {
         SPFieldUserValue usertoadd = ConvertLoginAccount(userarray[i]);
         usercollection.Add(usertoadd);
     }
     SPList list = SPContext.Current.Web.Lists["user tasks"];
     SPListItem item = list.Items.Add();
     item["Team"] = usercollection;
     item.Update();
    }
    public SPFieldUserValue ConvertLoginAccount(string userid)
    {
     SPFieldUserValue uservalue;
     using (SPSite site = new SPSite(SPContext.Current.Site.Url))
     {
         using (SPWeb web = site.OpenWeb())
         {
             SPUser requireduser = web.EnsureUser(userid);
             uservalue = new SPFieldUserValue(web, requireduser.ID, requireduser.LoginName);
         }
     }
     return uservalue;
    }
