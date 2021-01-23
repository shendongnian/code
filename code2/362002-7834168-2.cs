    public class MyBindingList<T> : BindingList<T>
    {
        protected override bool SupportsSearchingCore
        {
            get
            {
                return true;
            }
        }
        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            // Get the property info for the specified property. 
            PropertyInfo propInfo = typeof(T).GetProperty(prop.Name);
            T item;
            if (key != null)
            {
                // Loop through the items to see if the key 
                // value matches the property value. 
                for (int i = 0; i < Count; ++i)
                {
                    item = (T)Items[i];
                    if (propInfo.GetValue(item, null).Equals(key))
                        return i;
                }
            }
            return -1;
        } 
    }
