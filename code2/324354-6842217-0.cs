    User returnuser;
    string sql = "SELECT usertype, datecreated, email, name, phone, country, ip, company, companyreg, securityquestion, securityanswer, description, accountbalance, aothcredits, wantsrequests FROM ruser WHERE userid=@userid";        
    try 
       {
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand(sql))
            {
                con.Open();
                cmd.Connection = con;
                cmd.Parameters.Add("@userid", System.Data.SqlDbType.Int).Value = userid;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        string type = rdr.GetString(0);
                        if (type == "agent")
                        {
                            Agent agent = user as Agent;
                            agent.Company = rdr["company"].ToString();
                            agent.CompanyReg = rdr["companyreg"].ToString();
                            agent.SecurityQuestion = rdr["securityQuestion"].ToString();
                            agent.SecurityAnswer = rdr["securityanswer"].ToString();
                            agent.Description = rdr["description"].ToString();
                            agent.AccountBalance = (int)rdr["accountbalance"];
                            agent.WantsRequests = Convert.ToBoolean(rdr["wantsrequests"]);
                            returnuser = agent;
                        }
                        else //type == "client"
                        {
                            Client client = user as Client;
                            client.Country = rdr["country"].ToString();
                            client.IP = rdr["ip"].ToString();
                            returnuser = client;
                        }
                        returnuser.UserId = userid;
                        returnuser.UserType = rdr["usertype"].ToString();
                        returnuser.DateCreated = (DateTime)rdr["datecreated"];
                        returnuser.Email = rdr["email"].ToString();
                        returnuser.Name = rdr["name"].ToString();
                        returnuser.Phone = rdr["phone"].ToString();
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
