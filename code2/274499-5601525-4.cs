    static bool DerivedFromBase(Type type)
        {
            Type openBase = typeof(Base<>);
           
            var baseType = type;
            while (baseType != typeof(Object) && baseType != null)
            {
                if (baseType.GetGenericTypeDefinition() == openBase) return true;
                baseType = baseType.BaseType;
            }
            return false;
        }
