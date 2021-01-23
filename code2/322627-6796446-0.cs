     <!-- Register you're handler web.config -->
     <system.web>
     ...
         <httpHandlers>
             <add verb="*" path="People.axd" type="YourLibNameSpace, PeopleHandlerFactory" />
         </httpHandlers>
     ...
     </system.web>
     public class PeopleHandlerFactory: IHttpHandlerFactory
     {
          public virtual IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
             
             Page p = new Page();
            p.SetRenderMethodDelegate(delegate (HtmlTextWriter writer) 
                {
                    // ... some standard html tags if so desired
                    foreach (var person in People)
                    {
                        writer.Write(person.ToString());
                    }
                });
             return p;
        }
     }
