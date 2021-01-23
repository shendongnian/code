    HtmlElement el = webBrowser1.Document.All["mybutton"];
    object obj = el.DomElement;
    System.Reflection.MethodInfo mi = obj.GetType().GetMethod("click");
    mi.Invoke(obj, new object[0]); 
   
