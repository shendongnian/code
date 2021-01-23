    HtmlElement el = extWebbrowser.Document.Window.Frames["YourFrame"].Document.All["YourElement"];
    object obj = el.DomElement;
    System.Reflection.MethodInfo mi = obj.GetType().GetMethod("click");
    mi.Invoke(obj, new object[0]);
 
  
