    static public class EXTENSIONS
    {
        static public IEnumerable<T> AsEnumerable<T>(this object thisObj) {
            if (ReferenceEquals(null, thisObj))
                yield break;
            foreach (T val in thisObj.GetType().GetFields().Where(f => f.IsLiteral).Select(f => f.GetValue(null)).OfType<T>())
                yield return val;
        }
    }
