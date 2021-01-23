        public static ObjectClass CreateFromFile(FileStream sourceFile)
        {
            .. parse source file
            if (!parseOk)
            {
                throw new ParseException(parseErrorDescription);
            }
            return new ObjectClass(my, constructor, parameters);
        }
        public static bool TryCreateFromFile(FileStream sourceFile, out ObjectClass obj)
        {
            obj = null;
            .. parse source file
            if (!parseOk)
            {
                return false;
            }
            obj = new ObjectClass(my, constructor, parameters);
            return true;
        }
