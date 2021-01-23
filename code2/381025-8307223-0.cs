         public void UpdateCustomerLastUpdateStatus(Customer c)
            {
            using ( var context = new this.DataContext())  
        // if you have created object on page then it may no need to create object again for DataContext
            {
                
    Customer cust = DataContext.Customer.Single(cu => cu.ID == c.ID);
    // Validate cust that your Customer Id if it is supposed to be null reference issue.
    cust.LastWebLogIn = DateTime.Now;
            
                String ipAddress = System.Web.HttpContext.Current.Request.UserHostAddress;
            
                WebsiteTracking web_track = new WebsiteTracking();
                web_track.ActiveLoginDate = DateTime.Now;
                web_track.IPAddress = ipAddress;
            
                cust.WebsiteTracking.Add(web_track);
                //or
                DataContext.WebsiteTracking.Add(web_track);
            
                this.DataContext.SaveChanges();
            }            
            
            }
