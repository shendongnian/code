    public class Special1 : DoStuff
    {
        protected override DoStuffImpl(var x)
        {
            // work with x here
        }
    } // eo class Special1
    public class Special2 : DoStuff
    {
        protected override DoStuffImpl(var x)
        {
            // work with x here, but in a different way
        }
    } // eo class Special2
    // work with them
    Special1 s1; s1.DoMethod();
    Special2 s2; s2.DoMethod();
