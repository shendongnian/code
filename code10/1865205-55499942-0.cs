     if (dr.Read())
                {
                    if (Convert.ToInt32(dr["u_role"]) == 1) {
                        con.Close();
                        return View("Create");
                    }
                    else
                    {
                        con.Close();
                        return View("Error");
                    }
                }
                else
                {
                    con.Close();
                    return View("Error");
                }
