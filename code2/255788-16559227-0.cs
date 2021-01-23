    public static class UserControlExtension
    {
        public static IEnumerable<T> GetAllMembersByType<T>(this UserControl sourceObj, Type requiredType)
        {
            var members = sourceObj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var found = members.Where(fi => fi.FieldType.Equals(requiredType));
 
            List<T> items = new List<T>();
            foreach (var fld in found)
            {
                T val = (T)fld.GetValue(sourceObj);
                items.Add(val);
            }
 
            return items;
        }
 
        public static T GetMemberByNameAndType<T>(this UserControl sourceObj, string requiredName, Type requiredType)
        {
            var members = sourceObj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var found = members.Where(fi => fi.FieldType.Equals(requiredType) && fi.Name == requiredName);
 
            if (found.Any())
            {
                var fld = found.FirstOrDefault();
                T val = (T)fld.GetValue(sourceObj);
                return val;
            }
 
            throw new Exception("No member found.");
        }
 
 
    }
