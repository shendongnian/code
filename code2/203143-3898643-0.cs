    static public class Util {
    
        // C# iterator implementation
        static public IEnumerable<T> AsEnumerable<T>(Type t)
        {
            if (ReferenceEquals(null, t))
                yield break;
            foreach (T val in t.GetFields().Where(f => f.IsLiteral).Select(f => f.GetValue(null)).OfType<T>())
                yield return val;
        }
    }
