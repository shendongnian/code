    public class pnpropo
    {
        public List<System.Web.UI.WebControls.ListItem> propo { get; set; }
    }
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod]
    public static void Savepnpro(pnpropo pro)
    {
       string xpro = string.Empty;
    
       foreach (System.Web.UI.WebControls.ListItem item in pro.propo) 
       {
          if (item.Selected)
          {
             xpro += item.Value + "; ";
          }
       }
    }
