    using (var a = File.CreateText(@"c:\temp\test.txt"))  //#1
    {
        // a is only visible in this context
    }
    TextWriter w;
    using(w = File.CreateText(@"c:\temp\test.txt")) //#2
    {
        // w is visible outside of this context, but is only valid within the context
    }
    w = File.CreateText(@"c:\temp\test.txt");
    using (w)                                       //#3
    {
        // w is visible outside of this context, but is only valid between assignment and end of this context
    }
    using (File.CreateText(@"c:\temp\test.txt"))    //#4
    {
        // the disposable is not visible in any context
    }
