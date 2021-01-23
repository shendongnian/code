        static private Assembly GetWebEntryAssembly()
        {
            if (System.Web.HttpContext.Current == null ||
                System.Web.HttpContext.Current.ApplicationInstance == null) 
            {
                return null;
            }
            var type = System.Web.HttpContext.Current.ApplicationInstance.GetType();
            while (type != null && type.Namespace == "ASP") {
                type = type.BaseType;
            }
            return type == null ? null : type.Assembly;
        }
