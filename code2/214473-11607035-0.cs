       //The path where the web.config file is located
       string path = "~/Administrator/";
       //Collections of aspx page names separated by a comma. 
       //Example content in a textbox: Default.aspx,Audit.aspx,
       string strPages = txtPages.Text;
       //This is string array where we are going to break down all name of aspx pages 
       //contained in strPages variable
       string[] cdrPages = strValues.Split(',');
       //This is the list where we are going to transfer the names of our aspx pages 
       //for faster searching of existing items
       
       List<string> accesslist = new List<string>();
       try
            {
                //1. Create Role
                System.Web.Security.Roles.CreateRole(this.txtRoleName.Text);
                //2. Open the Web Configuration --> make sure that you put the correct folder location of your web.config file
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(path);
                //3. Get All Specified Locations
                ConfigurationLocationCollection myLocationCollection = config.Locations;
                //4. Transfer the values of string[] strPages to List<string> accessList
                for (int i = 0; i < strPages.Length; i++)
                {
                    if (strPages[i].ToString() != null && strPages[i].ToString() != "")
                    {
                        accesslist.Add(strPages[i].ToString());
                    }
                }
                //5. Loop through the LocationCollections
                foreach (ConfigurationLocation myLocation in myLocationCollection)
                {
                    //6. Checks if myLocation exists in List<string> accessList
                    bool exists = accesslist.Exists(element => element == myLocation.Path); 
            
                    //If Exists
                    if (exists) {
                        
                        //7. Open the configuration of myLocation
                        System.Configuration.Configuration sub = myLocation.OpenConfiguration();
                        //8. Get the authorization section of specific location
                        AuthorizationSection section = (System.Web.Configuration.AuthorizationSection)sub.GetSection("system.web/authorization");
                        
                        //9. Declare the Authorization Rule, in this case, we are allowing a new role to have an access to a specific page
                        AuthorizationRule autho = new System.Web.Configuration.AuthorizationRule(System.Web.Configuration.AuthorizationRuleAction.Allow);
                        
                        //10. Add the New Role to Authorization Section
                        autho.Roles.Add(this.txtRoleName.Text);
                        section.Rules.Add(autho);
                        //11. Save the "sub", or the specific location inside the web.config file.
                        sub.Save();
                    }
                }
                    message.InnerHtml = "Role Successfully Added!";
                    message.Attributes.Add("class", "msg_info");
            }
            catch {
                    message.InnerHtml = "Saving Failed";
                    message.Attributes.Add("class", "msg_error");
            }
            
