    public static class Utils
    {
        public static string MyFunc(string controlClassName)
        {
            string result = "";
            // get a list of all assemblies in this application domain
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            // the trouble is that we don't know which assembly the class is defined in,
            // because we are using the "Web Site" model in Visual Studio that compiles
            // them on the fly into assemblies with random names
            // -> however, we do know that the assembly will be named App_Web_*
            // (http://msdn.microsoft.com/en-us/magazine/cc163496.aspx)
            foreach (Assembly assembly in assemblies)
            {
                if (assembly.FullName.StartsWith("App_Web_"))
                {
                    // I have specified the ClassName attribute of the <%@ Control %>
                    // directive in the relevant ASCX files, so this should work
                    Type t = assembly.GetType("ASP." + controlClassName);
                    if (t != null)
                    {
                        // use reflection to create the instance (as a general object)
                        object o = Activator.CreateInstance(t);
                        // cast to the common base type that has the property we need
                        CommonBaseType ctrl = o as CommonBaseType;
                        if (ctrl != null)
                        {
                            foreach (string key in ctrl.PropertyWeNeed)
                            {
                                // finally, do the actual work
                                result = "something good";
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
