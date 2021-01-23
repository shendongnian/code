    class Program
        {
            static void Main(string[] args)
            {
                Deserialize(@"..\..\v1.xml");
            }
    
            private static Model Deserialize(string file)
            {
                XDocument xdoc = XDocument.Load(file);
                var verAtt = xdoc.Root.Attribute(XName.Get("Version"));
                Model m = Deserialize<Model>(xdoc);
    
                IModelLoader loader = null;
    
                if (verAtt == null)
                {
                    loader = GetLoader("1.0");
                }
                else
                {
                    loader = GetLoader(verAtt.Value);
                }
    
                if (loader != null)
                {
                    loader.Populate(ref m);
                }
                return m;
            }
    
            private static IModelLoader GetLoader(string version)
            {
                IModelLoader loader = null;
                switch (version)
                {
                    case "1.0":
                        {
                            loader = new ModelLoaderV1();
                            break;
                        }
                    case "2.0":
                        {
                            loader = new ModelLoaderV2();
                            break;
                        }
                    case "3.0": { break; } //Current
                    default: { throw new InvalidOperationException("Unhandled version"); }
                }
                return loader;
            }
    
            private static Model Deserialize<T>(XDocument doc) where T : Model
            {
                Model m = null;
                using (XmlReader xr = doc.CreateReader())
                {
                   XmlSerializer xs = new XmlSerializer(typeof(T));
                   m = (Model)xs.Deserialize(xr);
                   xr.Close();
                }
                return m;
            }
        }
    
        public interface IModelLoader
        {
            void Populate(ref Model model);
        }
    
        public class ModelLoaderV1 : IModelLoader
        {
            public void Populate(ref Model model)
            {
                model.City = string.Empty;
                model.Phone = "(000)-000-0000";
            }
        }
    
        public class ModelLoaderV2 : IModelLoader
        {
            public void Populate(ref Model model)
            {
                model.Phone = "(000)-000-0000";
            }
        }
    
        public class Model
        {
            [XmlAttribute(AttributeName = "Version")]
            public string Version { get { return "3.0"; } set { } }
            public string Name { get; set; } //V1, V2, V3
            public string City { get; set; } //V2, V3
            public string Phone { get; set; } //V3 only
            
        }
