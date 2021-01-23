    public static void listFields(Type type, bool sameNamespace, int nestLevel = 1) {
        BindingFlags bf = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        Console.WriteLine("\r\n{0}Fields of {1}:", tabs(nestLevel - 1), type.Name);
        foreach (FieldInfo f in type.GetFields(bf)) {
            Console.WriteLine("{0}{1} {2} {3}", tabs(nestLevel), (f.IsPublic ? "public" : "private"), f.FieldType.Name, f.Name);
            Type fieldType = (f.FieldType.IsArray) ? f.FieldType.GetElementType() : f.FieldType;
            if ((type != fieldType) && (!sameNamespace || fieldType.Namespace == type.Namespace)) {
                listFields(fieldType, sameNamespace, nestLevel + 2);
            }
        }
        Console.WriteLine();
    }
    private static String tabs(int count) { return new String(' ', count * 3); }
