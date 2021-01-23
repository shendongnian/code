        public static class DataTypes
        {
            public static ReadOnlyCollection<TypeDescriptor> AvailableTypes;
            static DataTypes()
            {
                List<TypeDescriptor> Types = new List<TypeDescriptor>();
                Types.Add(new TypeDescriptor(new MyTypeA()));
                Types.Add(new TypeDescriptor(new MyTypeB()));
                AvailableTypes = new ReadOnlyCollection<TypeDescriptor>(Types);
            }
        }
