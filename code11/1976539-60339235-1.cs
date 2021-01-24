    [Parameter]
            public Dictionary<int, PropHolder> Props{ get; set; }
            public void GetAllProps()
            {
                Props = new Dictionary<int, PropHolder>();
                //nfo = SCustomer.GetType().GetProperties();
                int Cid = 0;
                foreach (PropertyInfo pif in SCustomer.GetType().GetProperties())
                {
                    Props[Cid] = new PropHolder(pif, pif.PropertyType.Name);
                    Cid++;
                }
            }
    
            public string CheckName(PropHolder propertyInfo)
            {
                if (propertyInfo.GetType() == typeof(PropHolder))
                {
                    return propertyInfo.type;
                }
                else
                {
                    return propertyInfo.GetType().Name.ToString();
                }
    
            }
            public PropertyInfo getInfo(PropHolder propertyInfo)
            {
                if (propertyInfo.GetType() == typeof(PropHolder))
                {
                    return propertyInfo.info;
                }
                else
                {
                    return null;
                }
            }
