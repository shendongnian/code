    int counter;
    if (Request.Cookies["counter"] == null)
        counter = 0;
    else
    {
        counter = int.Parse(Request.Cookies["counter"].Value);
    }
    counter++;
    
    Response.Cookies["counter"].Value = counter.ToString();
    Response.Cookies["counter"].Expires = DateTime.Now.AddDays(1);
