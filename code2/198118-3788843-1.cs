    public static class DomainTranslator
    {
        public static ServiceType Translate( ClientType type )
        {
            return new ServiceType { FieldOne = type.FieldOne, FieldTwo = type.FieldTwo };
        }
    }
