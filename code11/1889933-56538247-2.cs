    public string PrintMe(MyClass1 mc)
    {
      return PrintMe(mc as object);
    }
    public string PrintMe(MyClass2 mc)
    {
      return PrintMe(mc as object);
    }
