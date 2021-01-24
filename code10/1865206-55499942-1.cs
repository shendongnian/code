     if (dr.Read())
                {
                    if (Convert.ToInt32(dr["u_role"]) == 1) {
                        con.Close();
                        return View("AdminHome");
                    }
                    else
                    {
                        con.Close();
                        return View("UserHome");
                    }
                }
                else
                {
                    con.Close();
                    return View("Error");
                }
