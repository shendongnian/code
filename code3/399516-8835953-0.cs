    string authorization = Request.Headers["Authorization"];
    string userInfo;
    string username = "";
    string password = "";
    if (authorization != null)
    {
         byte[] tempConverted = Convert.FromBase64String(authorization.Replace("Basic ", "").Trim());
         userInfo = System.Text.Encoding.UTF8.GetString(tempConverted);
         string[] usernamePassword = userInfo.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
         username = usernamePassword[0];
         password = usernamePassword[1];
    }
    if (username == "yourusername" && password == "yourpassword")
    {
    }
    else
    {
         Response.AddHeader("WWW-Authenticate", "Basic realm=\"Test\"");
         Response.StatusCode = 401;
         Response.End();
    }
