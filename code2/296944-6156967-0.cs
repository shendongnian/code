        public static HtmlString ApplicationVersion(this HtmlHelper helper)
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            var version = asm.GetName().Version;
            var product = asm.GetCustomAttributes(typeof(System.Reflection.AssemblyProductAttribute), true).FirstOrDefault() as System.Reflection.AssemblyProductAttribute;
            if (version != null && product != null)
            {
                return new HtmlString(string.Format("<span>{0} v{1}.{2}.{3} ({4})</span>", product.Product, version.Major, version.Minor, version.Build, version.Revision));
            }
            else
            {
                return new HtmlString("");
            }
        }
