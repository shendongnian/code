    string connString;
    if(IsAdmin(user))
        connString = ConfigurationManager.ConnectionStrings["GameHutDBEntities1"];
    else
        connString = ConfigurationManager.ConnectionStrings["GameHutDBEntities2"];
    using(EntityConnection con = new EntityConnection(connString))
    {
      using (Entities context = new Entities(con))
      {
          // Some code here
      }
    }
