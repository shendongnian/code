    <%@ WebHandler Language="C#" Class="LastPlayed" %>
    
    using System;
    using System.Web;
    using System.Web.SessionState;
    
    public class LastPlayed : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable { get { return false; } }
        
        public void ProcessRequest (HttpContext context) {
    
            context.Response.ContentType = "text/plain";
            
            string GameTitle = context.Request["gt"];
            string GameAlias = context.Request["ga"];
    
            System.Collections.Specialized.OrderedDictionary GamesDictionary = (System.Collections.Specialized.OrderedDictionary)context.Session["LastPlayed"];
    
            if (context.Session["LastPlayed"] == null)
                // Creates and initializes a OrderedDictionary.
                GamesDictionary = new System.Collections.Specialized.OrderedDictionary();       
            try
            {
                if (GamesDictionary.Count >= 5)
                    // Remove the last entry from the OrderedDictionary
                    GamesDictionary.RemoveAt(GamesDictionary.Count - 1);
                // Insert a new key to the beginning of the OrderedDictionary
                GamesDictionary.Insert(0, GameTitle, GameAlias);
                context.Session["LastPlayed"] = GamesDictionary;
                context.Response.Write("Added");
            }
            catch { context.Response.Write("Duplicate Found."); }
           
        }
         
    }
