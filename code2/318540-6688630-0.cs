    // when AdditionalMethod gets called, it's as if it's from inside the class, and it has
    // a reference to the object it was called from. However, you can't access
    // private/protected fields.
    public static string AdditionalMethod(this A instance)
    {
        return "asdf";
    }
}
