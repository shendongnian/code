    int limit = Request.Cookies.Count; //Get the number of cookies and 
                                       //use that as the limit.
    HttpCookie aCookie;   //Instantiate a cookie placeholder
    string cookieName;   
    //Loop through the cookies
    for(int i = 0; i < limit; i++)
    {
     cookieName = Request.Cookies[i].Name;    //get the name of the current cookie
     aCookie = new HttpCookie(cookieName);    //create a new cookie with the same
                                              // name as the one you're deleting
     aCookie.Value = "";    //set a blank value to the cookie 
     aCookie.Expires = DateTime.Now.AddDays(-1);    //Setting the expiration date
                                                    //in the past deletes the cookie
     Response.Cookies.Add(aCookie);    //Set the cookie to delete it.
    }
