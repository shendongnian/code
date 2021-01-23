    System.Collections.Specialized.NameValueCollection cookiecoll = new System.Collections.Specialized.NameValueCollection();
    for(int i = 0 ; i < imageList.Length; i++)
    {
        cookiecoll.Add("item_" + i,imageList[i] );
    }
    HttpCookie cookielist = new HttpCookie("MyListOfCookies");
    cookielist.Values = cookiecoll;
    Response.Cookies.Add(cookielist);
