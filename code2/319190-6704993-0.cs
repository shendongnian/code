    class GenericTypeDescription
    {
        private readonly Type openGenericType;
        private readonly Type[] typeParameters;
        
        public GenericTypeDescription(Type openGenericType)
        {
            // add checks for openGenericType actually being what it says here
            this.openGenericType = openGenericType;
            this.typeParameters = new Type[openGenericType.GetGenericArguments().Length];
        }
        
        public void SetTypeParameter(int index, Type type) {
            // add error handling to taste
            this.typeParameters[index] = type;
        }
        
        public Type ConstructGenericType() {
            // add error handling to taste
            return this.openGenericType.MakeGenericType(this.typeParameters);
        }
    }
