    public interface INonGenericDictionary
    {
        // Members which don't rely on the type parameters
    }
    public class Dictionary<TKey, TValue> : INonGenericDictionary
    {
        ...
    }
