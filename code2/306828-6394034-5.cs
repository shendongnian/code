        string ToXml(object o)
        {
            XmlSerializer ser = new XmlSerializer(o.GetType());
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
                ser.Serialize(sw, o);
            return sb.ToString();
        }
