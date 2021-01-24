    HttpCookie Abc = new HttpCookie("Abc");
    DateTime now = DateTime.Now;
    Abc.Domain = ".example.com";
    //Abc Set the cookie value.
    Abc.Value = txt1.Text;
    // Set the cookie expiration date.
    Abc.Expires = now.AddMinutes(1);
    
    // Add the cookie.
    Response.Cookies.Add(Abc);
