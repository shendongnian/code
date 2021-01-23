    public sealed class A // this could even be from a dll that you don't have source code to
    {
    }
    public static class AExtensionMethods
    {
        // when AdditionalMethod gets called, it's as if it's from inside the class, and it            
        // has a reference to the object it was called from. However, you can't access
        // private/protected fields.
        public static string AdditionalMethod(this A instance)
        {
            return "asdf";
        }
    }
