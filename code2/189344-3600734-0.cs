    List<Control> allControls = new List<Control>();
                List<string> selectedIDs = new List<string>();
            
            foreach (Control c in this.pnlTable.Controls)
            {
                allControls.Add(c);
                if (c.Controls.Count > 0)
                {
                    foreach (Control childControl in c.Controls)
                    {
                        allControls.Add(childControl);
                        if (childControl.Controls.Count > 0)
                        {
                            foreach (Control childControl2 in childControl.Controls)
                            {
                                allControls.Add(childControl2);
                                if (childControl2.Controls.Count > 0)
                                {
                                    foreach (Control childControl3 in childControl2.Controls)
                                    {
                                        allControls.Add(childControl3);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach (Control control in allControls)
            {
                if (control is CheckBox)
                {
                    if (((CheckBox)(control)).Checked)
                    {
                        selectedIDs.Add(((CheckBox)(control)).ID);
                    }
                }
            }
