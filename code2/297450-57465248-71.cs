    internal static class TypeDefinitionExtensions
    {
        public static bool FullNameMatches(this TypeDefinition typeDefinition, Type type) =>
            typeDefinition.FullName.Replace("/", "").Equals(type.FullName.Replace("+", ""));
    }
