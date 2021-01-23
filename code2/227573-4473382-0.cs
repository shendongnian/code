    [Test]
    public void Country_Can_Be_Added()
    { 
      new MyService().AddCountry("xy");
    }
    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void Duplicate_Country_Can_Not_Be_Added()
    { 
      new MyService().AddCountry("yx");
    }
