    protected void mnuMaster_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            if (Session["Translator"] != null)
            {
                if (mnuMaster.Items.Count > 0)
                {
                    foreach (MenuItem mi in mnuMaster.Items)
                    {
                        if (mi.Text == "Tools")
                        {
                            mi.Selected = true;
                            Session["Translator"] = null;
                        }
                    }
                }
            }
        }
