            System.Xml.Serialization.XmlSerializer xs = new XmlSerializer(<my class>.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            if(<condition>)
            {
            ns.Add(string.Empty, @"x-schema:C:\UPSLabel\OpenShipments.xdr");
            } 
            else
            {
            ns.Add(string.Empty, @"x-schema:D:\UPSLabel\OpenShipments.xdr");
            }
            xs.Serialize(<stream>, <your class instance>,ns);
