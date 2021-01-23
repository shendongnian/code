    DateTime mydt; // You don't need to initialize this with a new DateTime
    if (com == null)
    {
        // Do something else, since nothing below this will work
    }
    var keyCode = com.KeyCode;
    var time = Request.QueryString["Time"];
    if (keyCode == null || time == null)
    {
        // Do something else, since nothing below this will work
    }
    mydt = Convert.ToDateTime(com.Decrypt(time.ToString(), keyCode.ToString()));
