                DateTime currentDate = DateTime.Now;
                var query = (from m in db.Users
                            where m.EmailAddress == emailAddress
                            select m.Last_Login_Date).Single();
                DateTime lastLoginDate = Convert.ToDateTime(query);
                TimeSpan diffDays = currentDate.Subtract(lastLoginDate);
                if (diffDays.TotalDays> 72)
                {
                     Response.Redirect("ResetPwd.aspx");
                }
                else
                {
                    Security.LoginUser(u.Name, u.Role, rememberMe);
                    u.Last_Login_Date = currentDate;
                   
                }
