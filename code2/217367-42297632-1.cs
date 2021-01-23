    public static List<T> DeepClone<T>(this IList<T> list, bool ignoreVirtualProps = false)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings();
        if (ignoreVirtualProps)
        {
            settings.ContractResolver = new IgnoreNavigationPropsResolver();
            settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.Formatting = Formatting.Indented;
        }
        var serialized = JsonConvert.SerializeObject(list, settings);
        return JsonConvert.DeserializeObject<List<T>>(serialized);
    }
