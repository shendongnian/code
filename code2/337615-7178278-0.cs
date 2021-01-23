                    Session["UserName"] =userResults.MemberId;
                    Session["Email"] = userResults.Email;
                    Session["Role"] = userResults.Role.ToString();
                    Session["MemberId"] = userResults.MemberId.ToString();
                    Session["Name"] = userResults.Name;
