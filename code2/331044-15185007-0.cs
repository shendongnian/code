         public  T GetAttributeFrom<T>( object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            T t = (T)property.GetCustomAttributes(attrType, false).FirstOrDefault();
            if (t == null)
            {
                MetadataTypeAttribute[] metaAttr = (MetadataTypeAttribute[])instance.GetType().GetCustomAttributes(typeof(MetadataTypeAttribute), true);
                if (metaAttr.Length > 0)
                {
                    foreach (MetadataTypeAttribute attr in metaAttr)
                    {
                        var subType = attr.MetadataClassType;
                        var pi = subType.GetField(propertyName);
                        if (pi != null)
                        {
                            t = (T)pi.GetCustomAttributes(attrType, false).FirstOrDefault();
                            return t;
                        }
                      
                    }
                }
              
            }
            else
            {
                return t;
            }
            return null; 
        }
