        using System;
        using System.IO;
        using System.Security.Permissions;
        using Microsoft.SharePoint;
        using Microsoft.SharePoint.Security;
        using Microsoft.SharePoint.Utilities;
        using Microsoft.SharePoint.Workflow;
        //Debugging includes
        using System.Diagnostics;
        namespace ARDT.Notifications
        {
            /// <summary>
            /// List Item Events
            /// </summary>
            public class Notifications : SPItemEventReceiver
            {
                /// <summary>
                /// An item was updated
                /// </summary>
                public override void ItemUpdated(SPItemEventProperties properties)
                {
                    if (properties.ListItem["updateContributors"].ToString().Equals("True"))
                    {
                        //work around so it goes through it only once instead of everytime the item is updated
                        properties.ListItem["updateContributors"] = "False";
                        SPSite site = new SPSite("http://sp2010dev/ardt/");
                        using (SPWeb web = site.OpenWeb())
                        {
                            SPList list = web.Lists["Document Collaboration"];
                            SPListItem listItem = properties.ListItem;
                            SPUser userName = null;
                            String toAddress = null;
                            //EMail initializations
                            bool appendHtmlTag = false;
                            bool htmlEncode = false;
                            string subject = "You have been assigned to a Document";
                            string message = "Test Message";
                            //get usernames
                            string tempFieldValue = listItem["Assigned To"].ToString();
                            string[] userNameArray = listItem["Assigned To"].ToString().Split(';');
                            //remove permissions first
                            web.AllowUnsafeUpdates = true;
                            listItem.BreakRoleInheritance(false);
                            SPRoleAssignmentCollection raCollection = listItem.RoleAssignments;
                            //remove exisiting permissions one by one
                            for (int a = raCollection.Count - 1; a >= 0; a--)
                            {
                                raCollection.Remove(a);
                            }
                            for (int i = 1; i < userNameArray.Length; i++)
                            {
                                tempFieldValue = userNameArray[i].Replace("#", "");
                                userName = web.AllUsers[tempFieldValue];
                                toAddress = userName.Email;
                                SPSecurity.RunWithElevatedPrivileges(delegate()
                                {
                                    //EMAIL USER
                                    bool result = SPUtility.SendEmail(web, appendHtmlTag, htmlEncode, toAddress, subject, message);
                                    //PERMISSIONS                              
                                    //grant permissions for specific list item
                                    SPRoleDefinition roleDefintion = web.RoleDefinitions.GetByType(SPRoleType.Contributor);
                                    SPRoleAssignment roleAssignment = new SPRoleAssignment(userName);
                                    roleAssignment.RoleDefinitionBindings.Add(roleDefintion);
                                    listItem.RoleAssignments.Add(roleAssignment);
                                    listItem.Update();
                                });
                                i++;
                            }
                        }
                        //base.ItemUpdated(properties);
                        //after final update has been done return true
                        properties.ListItem["updateContributors"] = "True";
                    }
                }
        
            }
        
        }
