        public void binddrop(StringCollection colle)
        {
    
            var userdetails = 
            (
                from elem in colle.Cast<string>()
                from mail in elem.Split('|')
                join users in objdata on mail equals users.Email
                where users.UserType != null 
                   select new
                   {
                       Name = users.FirstName,
                       ID = users.UserId
                   }
            );
    
    
            drpvendor.DataSource = userdetails;
            drpvendor.DataTextField = "Name";
            drpvendor.DataValueField = "ID";
            drpvendor.DataBind();
    
    
            drpvendor.Items.Insert(0, new ListItem("-Select Vendor-", "0"));
    
        }
