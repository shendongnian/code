    public class PropertyReader
    {
        public static List<Prop> GetPropertiesWithPrefix(object obj, string prefix)
        {
            if (obj == null)
            {
                return new List<Prop>();
            }
            var allProps = from propInfo
                           in obj.GetType().GetProperties()
                           select new Prop()
                           {
                               Name = prefix + propInfo.Name,
                               Value = propInfo.GetValue(obj, null) as string
                           };
            return allProps.ToList();
        }
    }
