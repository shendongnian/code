    namespace ServiciosWeb 
        { 
           [WebService(Namespace = "http://tempuri.org/")] 
           [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)] 
           [System.ComponentModel.ToolboxItem(false)] 
           public partial class Services : System.Web.Services.WebService 
           { 
           } 
     
       public partial class Services : Services.IService 
       { 
          [WebMethod] 
          public string GetImage() 
          { 
            return "Image"; 
          } 
       } 
     
      public partial class Services : Services.IService 
      { 
        [WebMethod] 
        public string User() 
        { 
            return "User"; 
        } 
      } 
    } 
