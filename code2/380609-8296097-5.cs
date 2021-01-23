        [WebMethod]
        public static string GetControlViaAjax()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("CssClass", "YourCSSClass");
            d.Add("Title", "Your title");
            return RenderUserControl("/yourcontrol.ascx", true, d);
        }  
        private static string RenderUserControl(string path, bool useFormLess,
             Dictionary<string, object> controlParams)
        {
    
            Page pageHolder = null;
            if (useFormLess)
            {
                pageHolder = new FormlessPage() { AppRelativeTemplateSourceDirectory = HttpRuntime.AppDomainAppVirtualPath }; //needed to resolve "~/"
            }
            else
            {
                pageHolder = new Page() { AppRelativeTemplateSourceDirectory = HttpRuntime.AppDomainAppVirtualPath };
            }
            
            //load assembly and usercontrol when .ascx is compiled into a .dll
            //string assemblyName = "Com.YourNameSpace.UI";
            //string controlAssemblyName = string.Format("{0}.{1},{0}", assemblyName, "AwesomeControl");
 
            //Type type = Type.GetType(controlAssemblyName);            
            //UserControl viewControl = LoadControl(type, null);
              
            UserControl viewControl =
               (UserControl)pageHolder.LoadControl(path);
    
            viewControl.EnableViewState = false;
    
            if (controlParams != null && controlParams.Count > 0)
            {
                foreach (var pair in controlParams)
                {
                    Type viewControlType = viewControl.GetType();
                    PropertyInfo property =
                       viewControlType.GetProperty(pair.Key);
    
                    if (property != null)
                    {
                        property.SetValue(viewControl, pair.Value, null);
                    }
                    else
                    {
                        throw new Exception(string.Format(
                           "UserControl: {0} does not have a public {1} property.",
                           path, pair.Key));
                    }
                }
            }
    
            if (useFormLess)
            {                
                pageHolder.Controls.Add(viewControl);
            }
            else
            {
                HtmlForm form = new HtmlForm();
                form.Controls.Add(viewControl);
                pageHolder.Controls.Add(form);
            }
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
