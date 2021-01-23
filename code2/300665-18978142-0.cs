    public static class RuntimeTypeModelExt
    {
        public static MetaType Add<T>(this RuntimeTypeModel model)
        {
            var publicFields = typeof(T).GetFields().Select(x => x.Name).ToArray();
            return model.Add(typeof(T), false).Add(publicFields);
        }
    }
