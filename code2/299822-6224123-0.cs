    for (int count = 0; count < gvAppRejProfiles.Rows.Count; count++)
                    {
                        LinkButton lbtnResumes = (LinkButton)gvAppRejProfiles.Rows[count].FindControl("lbtnResumes");
                        if (lbtnResumes.Text == "resume")
                        {
                            // Store and perform any operation
                        }
                    }
