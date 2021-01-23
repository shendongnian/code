    [Test]
    public void ValidateIdentifiers()
    {
      Regex regex = new Regex(
      @"^@?_*[\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Nl}\p{Mn}\p{Mc}\p{Cf}\p{Pc}\p{Lm}]*$");
      Assert.That(regex.IsMatch("Bling"),   Is.True);
      Assert.That(regex.IsMatch("@_Bling"), Is.True);
      Assert.That(regex.IsMatch("__Bling"), Is.True);
      Assert.That(regex.IsMatch("__Bling"), Is.True);
      Assert.That(regex.IsMatch("__Bling"), Is.True);
      Assert.That(regex.IsMatch("السياحى"), Is.True);
      Assert.That(regex.IsMatch("_@Bling"), Is.False);
    }
