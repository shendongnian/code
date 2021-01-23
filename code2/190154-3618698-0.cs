      using (FileStream fs = File.Create(fileName))
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlRootAttribute root = new XmlRootAttribute("Persons");
            XmlSerializer
                ser = new XmlSerializer(typeof(Person[]), root);
            ser.Serialize(fs, obj, ns);
        }
