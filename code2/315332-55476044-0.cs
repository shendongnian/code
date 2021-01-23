    public class CopyAndWriteList<T>
    {
        public static List<T> Clear(List<T> list)
        {
            var a = new List<T>(list);
            a.Clear();
            return a;
        }
        public static List<T> Add(List<T> list, T item)
        {
            var a = new List<T>(list);
            a.Add(item);
            return a;
        }
        public static List<T> RemoveAt(List<T> list, int index)
        {
            var a = new List<T>(list);
            a.RemoveAt(index);
            return a;
        }
        public static List<T> Remove(List<T> list, T item)
        {
            var a = new List<T>(list);
            a.Remove(item);
            return a;
        }
    }
