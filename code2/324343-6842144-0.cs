    public User GetUser(int userid)
        {
            User user;
            string sql = "...";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    //.. Snip sql stuff ... //
                            string type = rdr.GetString(0);
                            if (type == "agent")
                            {
                                Agent agent = new Agent();
                                agent.Company = rdr["company"].ToString();
                                agent.CompanyReg = rdr["companyreg"].ToString();
                                agent.SecurityQuestion = rdr["securityQuestion"].ToString();
                                agent.SecurityAnswer = rdr["securityanswer"].ToString();
                                agent.Description = rdr["description"].ToString();
                                agent.AccountBalance = (int)rdr["accountbalance"];
                                agent.WantsRequests = Convert.ToBoolean(rdr["wantsrequests"]);
                                user = agent;
                            }
                            else //type == "client"
                            {
                                Client client = new Client();
                                client.Country = rdr["country"].ToString();
                                client.IP = rdr["ip"].ToString();
                                user= client;
                            }
                            // Now do generic things
                            user.UserId = userid;
                            user.UserType = rdr["usertype"].ToString();
                            user.DateCreated = (DateTime)rdr["datecreated"];
                            user.Email = rdr["email"].ToString();
                            user.Name = rdr["name"].ToString();
                            user.Phone = rdr["phone"].ToString();
                            return user;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return returnuser;
        }
