        public class WebAssemblyInfo
        {
            Assembly assy;
            public WebAssemblyInfo(Assembly assy)
            {
                this.assy = assy;
            }
            public string Description { get { return GetWebAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description); } }
            
             // I'm using someone else's idea below, but I can't remember who it was
            private string GetWebAssemblyAttribute<T>(Func<T, string> value) where T : Attribute
            {
                T attribute = null;
                attribute = (T)Attribute.GetCustomAttribute(this.assy, typeof(T));
                if (attribute != null)
                    return value.Invoke(attribute);
                else
                    return string.Empty;
            }
        }
    }
