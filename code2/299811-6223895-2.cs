    class ObjectClass
    {
        protected ObjectClass(...constructor parameters your object depends on...)
        {
        }
        public static ObjectClass CreateFromFile(FileStream sourceFile)
        {
            .. parse source file
            if (parseOk)
            {
                return new ObjectClass(my, constructor, parameters);
            }
            return null;
        }
    }
