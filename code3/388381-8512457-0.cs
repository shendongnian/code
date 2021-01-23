    foreach (Control c in Page.Form.Controls)
                {
                    //Response.Write("WORD2" + c.GetType());
                    if (c is Panel)
                    {
                        foreach (Control p in c.Controls)
                        {
                            if (p is CheckBoxList)
                            {
                                foreach (ListItem li in ((CheckBoxList)p).Items)
                                {
                                    li.Selected = false;
                                }
                            }
                        }
                    }
                }
