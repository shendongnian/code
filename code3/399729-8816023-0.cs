    foreach (System.Web.UI.WebControls.ListItem oItem in rdioListRoles.Items)
                        {
                            if (oItem.Selected) // if you want only selected
                            {
                               variable  = oItem.Value;
                            }
                            // otherwise get for all items
                          variable  = oItem.Value;
                        }
