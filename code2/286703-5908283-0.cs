    public static class TypeOneExtensions
    { 
        public static TypeTwo AsTypeTwo(this TypeOne typeOne)
        {
            return new TypeTwo
            {
                PropertyA = typeOne.PropertyA,
                PropertyB = typeOne.PropertyB,
                ...
            };
        }
    }
