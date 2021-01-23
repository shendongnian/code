    [Test]
    public void Country_Can_Be_Added()
    { 
      new MyService().AddCountry("xy");
    }
    [Test]
    public void Duplicate_Country_Can_Not_Be_Added()
    { 
      Assert.Throws<ArgumentException>(() => new MyService().AddCountry("yx"));
    }
