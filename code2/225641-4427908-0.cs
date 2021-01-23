     PropertyInfo[] info = strList.GetType().GetProperties();
            Dictionary<string, object> propNamesAndValues = new Dictionary<string, object>();
            foreach (PropertyInfo pinfo in info)
            {
                propNamesAndValues.Add(pinfo.Name, pinfo.GetValue());
            }
              
