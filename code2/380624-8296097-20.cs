        private static string RenderUserControl(string path, bool useFormLess,
             Dictionary<string, object> controlParams, string assemblyName, string controlName )
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
            
            UserControl viewControl = null;
            
            //use path by default
            if(String.IsNullOrEmpty(path))
            {    
                //load assembly and usercontrol when .ascx is compiled into a .dll        
                string controlAssemblyName = string.Format("{0}.{1},{0}", assemblyName, controlName );
 
                Type type = Type.GetType(controlAssemblyName);            
                viewControl = (UserControl)pageHolder.LoadControl(type, null);
            }
            else
            {
                viewControl = (UserControl)pageHolder.LoadControl(path);    
            }              
          
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
