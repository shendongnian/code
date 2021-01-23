     public void binddrop(StringCollection colle)
      {
    foreach (string str in (StringCollection)colle)
    {
        string[] user = str.Split('|'); 
        iPhoneDataContext objdata = new iPhoneDataContext();
        var userdetails = (from users in objdata.UserDetails.AsEnumerable()
                           where users.UserType != null && users.Email==user[2].ToString()
                           select new
                           {
                               Name = users.FirstName,
                               ID = users.UserId
                           });
             foreach (var v1 in userdetails)
                {
                    drpvendor.Items.Add(v1.Name);
                   drpvendor.Items.FindByText(v1.Name).Value = v1.ID.ToString();
                  
                }
      }
 
