    HtmlElementCollection inputs = doc.GetElementsByTagName("input");
    HtmlElement usr = inputs.GetElementsByName("username")[0];
    usr.setAttribute("value", strUsername);
    HtmlElement pwd = inputs.GetElementsByName("password")[0];
    pwd.GotFocus += new HtmlElementEventHandler(pwd_GotFocus);
    pwd.Focus();
