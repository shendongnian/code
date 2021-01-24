    public static class DictionaryExtensions
    {
        public static void Update(this IDictionary src, IDictionary dst)
        {
            foreach (var key in dst.Keys)
                if (src.Contains(key))
                {
                    if (src[key] is IDictionary a &&
                        dst[key] is IDictionary b)
                        a.Update(b);
                    else
                        src[key] = dst[key];
                }
                else
                {
                    src.Add(key, dst[key]);
                }
        }
    }
