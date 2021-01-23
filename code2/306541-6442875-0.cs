    public class AcceptsTypeConstructorFinder
        : IConstructorFinder
    {
        private readonly Type m_typeToAccept;
        public AcceptsTypeConstructorFinder(Type typeToAccept)
        {
            if (typeToAccept == null) { throw new ArgumentNullException("typeToAccept"); }
            m_typeToAccept = typeToAccept;
        }
        public IEnumerable<ConstructorInfo> FindConstructors(Type targetType)
        {
            return targetType.GetConstructors()
                .Where(constructorInfo => constructorInfo.GetParameters()
                    .Select(parameterInfo => parameterInfo.ParameterType)
                    .Contains(m_typeToAccept));
        }
    }
