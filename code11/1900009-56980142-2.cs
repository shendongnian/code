    public static class MyStringExtensionsGroup
    {
       public static string MethodOne(this Group1 group) => group.Source + "My Method One";
       public static string MethodTwo(this Group2 group) => group.Source + "My Method Two";
       public static Group1 Group1(this string source) => new Group1(source);
       public static Group2 Group2(this string source) => new Group2(source);
    }
