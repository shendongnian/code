    private void Foo()
    {
       Foo(string.Empty);
    }
    private void Foo(string optionalString)
    {
       // do foo.
       if (!string.IsNullOrEmpty(optionalString))
          // etc
    }
