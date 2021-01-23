            public void WriteXml(XmlWriter writer)
            {
                foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
                {
                    string name = propertyInfo.Name;
                    if (propertyInfo.DeclaringType != typeof(A))
                    {
                        object obj = propertyInfo.GetValue(this, null);
                        if (obj != null)
                        {
                            writer.WriteStartElement(name);
                            string value = obj.ToString();
                            writer.WriteValue(value);
                            writer.WriteEndElement();
                        }
                    }
                }
            }
