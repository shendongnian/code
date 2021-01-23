    class PageWithProperties
    {
        public bool IsLogout { get{ return (bool)Session["IsLogout"] }
                               set { Session["IsLogout"] = value; } }
    }
    class PageClass : PageWithProperties
    {
         void PageClassMethod()
         {
             if(IsLogout)
             {
     
             }
         }
    }
