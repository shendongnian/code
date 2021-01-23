    class MyJoinedSubclassConvention : IJoinedSubclassConvention
    {
        public void Apply(IJoinedSubclassInstance instance)
        {
            Type basetype = instance.Extends;
            while (basetype.IsAbstract)
            {
                basetype = basetype.BaseType;
            }
            instance.Key.Column(basetype.Name + "Id");
        }
    }
