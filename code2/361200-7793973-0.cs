        private static XDocument Serialize<T>(object obj)
        {
            XDocument ReturnValue = new XDocument();
            //Create our Serializer with the type that was passed in
            XmlSerializer Serializer = new XmlSerializer(typeof(T));
            //Serialize our object to a string writer
            System.IO.StringWriter sw = new System.IO.StringWriter();        
            Serializer.Serialize(sw, obj);
            //We use a string reader to read the string from our Writer (created when serialized)
            System.IO.StringReader sr; 
            sr = new System.IO.StringReader(sw.ToString());
            
            //Then we can load the string reader giving us an XDocument
            ReturnValue = XDocument.Load(sr);
            return ReturnValue;
        }
        private static T Deserialize<T>(XDocument Xdoc)
        {
            T ReturnValue;
            //Create our Serializer with the type that was passed in
            XmlSerializer Serializer = new XmlSerializer(typeof(T));
            //Create a string reader to access the XML data in our XDocument
            System.IO.StringReader sr = new System.IO.StringReader(Xdoc.ToString());
            //Deserialize the XML into our object
            ReturnValue = (T)Serializer.Deserialize(sr);
            return ReturnValue;
        }
