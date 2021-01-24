        protected void WriteTypedPrimitive(string name, string ns, object o, bool xsiType)
        {
            string value = null;
            string type;
            string typeNs = XmlSchema.Namespace;
            bool writeRaw = true;
            bool writeDirect = false;
            Type t = o.GetType();
            bool wroteStartElement = false;
            switch (t.GetTypeCode())
            {
                case TypeCode.String:
                    value = (string)o;
                    type = "string";
                    writeRaw = false;
                    break;
                case TypeCode.Int32:
                    value = XmlConvert.ToString((int)o);
                    type = "int";
                    break;
