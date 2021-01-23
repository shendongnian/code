        Dictionary<PropertyInfo, object[]> PI;
        public void InitClass()
        {
            PI = new Dictionary<PropertyInfo, object[]>();
            Type T = this.GetType();
            PropertyInfo[] propInfos = T.GetProperties();
            foreach (PropertyInfo info in propInfos)
            {
                var AObj = info.GetCustomAttributes(false);
                PI.Add(info, AObj);
            }
        }
        public void Load(XDocument data)
        {
            XElement XML;
            PropertyInfo item;
            object[] AObj;
            foreach (var keyValPair in PI)
            {
                item = keyValPair.Key;
                AObj = keyValPair.Value;
                XMLProfiles = data.Element("user").Element(((XmlElementAttribute)AObj[0]).ElementName);
                object Value = Parse(item, XML.Value);
                if (Value != null)
                    item.SetValue(this, Value, null);
            }
        }
