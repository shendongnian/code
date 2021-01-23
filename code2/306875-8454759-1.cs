    MasterPage m = Page.Master as MasterPage;
    Type t = m.GetType();
    
    System.Reflection.PropertyInfo pi = t.GetProperty("MyName");
    Response.Write( pi.GetValue(m,null)); //return "Nazmul"
