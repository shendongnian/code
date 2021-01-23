     public static T BuildNew<T>(BaseClass baseClass) where T : BaseClass, new()
     {
        return new T
        {
            Property1 = baseModel.Property1,
            Property2 = baseModel.Property2,
        };
     }
