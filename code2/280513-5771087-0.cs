        public static bool IsCOMObject(TypeDefinition type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            return (type.Attributes & TypeAttributes.Import) == TypeAttributes.Import;
        }
