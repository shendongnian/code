      [AttributeUsage(AttributeTargets.Class)]
        // [JetBrains.Annotations.BaseTypeRequired(typeof(Attribute))] uncomment if you use JetBrains.Annotations
        public class PropertyTypeAttribute : Attribute
        {
            public Type[] Types { get; private set; }
    
            public PropertyTypeAttribute(params Type[] types)
            {
                Types = types;
            }
        }
