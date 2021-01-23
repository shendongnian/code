    public class Tools
    {
        public static T[] Convert<T>(object[] objArr)
        {
            IList<T> list = new List<T>();
            foreach (var o in objArr)
            {
                list.Add((T)o);
            }
            return list.ToArray();
        }
    }
