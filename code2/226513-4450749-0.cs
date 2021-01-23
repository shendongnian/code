    public static class ViewStateExtensions
        {
             public static T GetTypedData<T>(this StateBag bag, string key)
             {
                 return (T) bag[key];
             }
             public static void SetTypedData<T>(this StateBag bag, string key, T value)
             {
                 bag[key] = value;
             }
        }
