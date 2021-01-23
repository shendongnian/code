    public string Checkavailability(string UserName)
            {
                if (UserName != "Enter text" && !String.IsNullOrEmpty(UserName))
                {
                    string userName = UserName.ToLower();
                    NorthwindEntities dbContext = new NorthwindEntities();
                    var query = from p in dbContext.Employees
                                where p.FirstName.ToLower() == userName
                                select p;
                    IEnumerable<Employee> rec = query.ToList();
    
                    if (rec.Count() == 0)
                    {
                        return "You entered: \"" + UserName.ToString() + "\" available ";
                    }
                    else
                    {
                        return "You entered: \"" + UserName.ToString() + "\" already exists " +
                          DateTime.Now.ToLongTimeString();
                    }
    
                }
    
                return String.Empty;
            }
