    public sealed class CacheKey : IEquatable<CacheKey>
    {
        private readonly Type reflectedType;
        private readonly Type returnType;
        private readonly string name;
        private readonly Type[] parameterTypes;
        private readonly object[] arguments;
        public User(Type reflectedType, Type returnType, string name, 
            Type[] parameterTypes, object[] arguments)
        {
            // check for null, incorrect values etc.
            this.reflectedType = reflectedType;
            this.returnType = returnType;
            this.name = name;
            this.parameterTypes = parameterTypes;
            this.arguments = arguments;
        }
    
        public override bool Equals(object obj)
        {
            return Equals(obj as CacheKey);
        }
        public bool Equals(CacheKey other)
        {
            if (other == null)
            {
                return false;
            }
            for (int i = 0; i < parameterTypes.Count; i++)
            {
                if (!parameterTypes[i].Equals(other.parameterTypes[i]))
                {
                    return false;
                }
            }
            for (int i = 0; i < arguments.Count; i++)
            {
                if (!arguments[i].Equals(other.arguments[i]))
                {
                    return false;
                }
            }
            return reflectedType.Equals(other.reflectedType) &&
               returnType.Equals(other.returnType) &&
               name.Equals(other.name);
        }
        private override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + reflectedType.GetHashCode();
                hash = hash * 31 + returnType.GetHashCode();
                hash = hash * 31 + name.GetHashCode();
                for (int i = 0; i < parameterTypes.Count; i++)
                {
                    hash = hash * 31 + parameterTypes[i].GetHashCode();
                }
                for (int i = 0; i < arguments.Count; i++)
                {
                    hash = hash * 31 + arguments[i].GetHashCode();
                }
                return hash;
            }
        }
    }
