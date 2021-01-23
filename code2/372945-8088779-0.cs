     [WebMethod]
     public static string GetMyUserControlHtml()
     {
         return  RenderUserControl("Com.YourNameSpace.UI", "YourControlName");
     }
     public static string RenderUserControl(string assembly,
                 string controlName)
     {
            FormlessPage pageHolder = 
                    new FormlessPage() { AppRelativeTemplateSourceDirectory = HttpRuntime.AppDomainAppVirtualPath }; //allow for "~/" paths to resolve
            dynamic control = null;
            HtmlForm form = new HtmlForm();
     
            //assembly = "Com.YourNameSpace.UI"; //example
            //controlName = "YourCustomControl"
            string fullyQaulifiedAssemblyPath = string.Format("{0}.{1},{0}", assembly, controlName);
            Type type = Type.GetType(fullyQaulifiedAssemblyPath);
            if (type != null)
            {
                control = pageHolder.LoadControl(type, null);
                control.Bla1 = "test"; //bypass compile time checks on property setters if needed
                control.Blas2 = true;
            }                          
      
            //form.Controls.Add(viewControl);
            pageHolder.Controls.Add(control);
            StringWriter output = new StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, output, false);
            return output.ToString();
     }
    
    public class FormlessPage : Page
    {
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
