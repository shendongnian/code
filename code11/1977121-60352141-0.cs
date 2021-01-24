    public Dictionary<string, string> ModelToDict<T>(T item)
        {
            Type myObjectType = item.GetType();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            PropertyInfo[] properties = myObjectType.GetProperties();
            foreach (var info in properties)
            {
                string value = (string)info.GetValue(item);
                dict.Add(info.Name, value);//change the order if you like
            }
            return dict;
        }
