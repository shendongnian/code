        void HandleUnknownElements(Show show, List<XmlElementEventArgs> unknownElementEvents, XmlAttributeOverrides overrides)
        {
            foreach (XmlElementEventArgs e in unknownElementEvents)
            {
                // (1) Dynamically create a type that simply inherits from UnknownMediaType 
                AssemblyName assName = new AssemblyName("Show Dynamic Type " + e.Element.Name + " Assembly");
                AssemblyBuilder assBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assName, AssemblyBuilderAccess.Run);
                ModuleBuilder modBuilder = assBuilder.DefineDynamicModule(assBuilder.GetName().Name);
                TypeBuilder typeBuilder = modBuilder.DefineType(e.Element.Name, TypeAttributes.Class | TypeAttributes.Public, typeof(UnknownMediaType));
                Type objectType = typeBuilder.CreateType();
                // (2) Add a root attribute to the type as override
                XmlAttributes attrs = new XmlAttributes();
                XmlRootAttribute xmlRoot = new XmlRootAttribute(e.Element.Name);
                attrs.XmlRoot = xmlRoot;
                XmlAttributeOverrides o = new XmlAttributeOverrides();
                o.Add(objectType, attrs);
                // (3) Use a memory stream for creating a temporary XML document that will be deserialized
                
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    XmlDocument doc = new XmlDocument();
                    doc.AppendChild(doc.ImportNode(e.Element, true));
                    doc.Save(memoryStream);
                    memoryStream.Position = 0;
                    // (4) Deserialize the object using an XmlSerializer and add it
                    try
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(objectType, o);
                        UnknownMediaType t = xmlSerializer.Deserialize(memoryStream) as UnknownMediaType;
                        show.MediaTypes.Add(t);
                    }
                    catch (Exception exc)
                    {
                        System.Diagnostics.Debug.WriteLine(exc.ToString());
                    }
                }
            }
        }
