    public string Encode(string strToEncode)
    {
        byte[] encodedVal = System.Text.Encoding.UTF8.GetBytes(strToEncode);
        return Convert.ToBase64String(encodedVal);
    }
    
    public string Decode(string strToDecode)
    {
        byte[] decodedVal = Convert.FromBase64String(strToDecode);
        return System.Text.Encoding.UTF8.GetString(decodedVal);
    }
    public ActionResult Login(string userName)
    {
       var userNameDecoded = Decode(userName);
       return View();
    }
    
    [HttpPost]
    public ActionResult Register(Account account)
    {
       ...
       return RedirectToAction("Login", "Account", new {userName=Encode(account.Username)});               
                
    }
