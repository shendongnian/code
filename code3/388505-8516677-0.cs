       if(usrFrnds.Count > 0 )
       {
       //DATA FOUND!
       grvMyFriends.DataSource = usrFrnds.ToList(); 
       grvMyFriends.DataBind();
       }
       else
       {
        //NO DATA FOUND!
       }
