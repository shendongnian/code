    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    
    namespace MessagingModule
    {
      public class MessagingAreaRegistration : AreaRegistration
      {
        public override string AreaName
        {
          get
          {
            return "Messaging";
          }
        }
    
        public override void RegisterArea( AreaRegistrationContext context )
        {
          context.MapRoute(
              "Messaging_default",
              "Messaging/{controller}/{action}/{id}",
              new { action = "Index", id = UrlParameter.Optional }
            //new[] { "MessagingModule.Controllers" }
          );
        }
    
      }
    }
