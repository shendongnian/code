    [Test]
    public void ValidateIdentifiers()
    {
      Regex regex = new Regex(
      @"^@?_*[\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Nl}\p{Mn}\p{Mc}\p{Cf}\p{Pc}\p{Lm}]*$");
      Assert.That(regex.IsMatch("Bling"),   Is.True,  "Bling");
      Assert.That(regex.IsMatch("@_Bling"), Is.True,  "@_Bling");
      Assert.That(regex.IsMatch("__Bling"), Is.True,  "__Bling");
      Assert.That(regex.IsMatch("__Bling"), Is.True,  "_Bling_");
      Assert.That(regex.IsMatch("__Bling"), Is.True,  "_Bling_Bling");
      Assert.That(regex.IsMatch("__Bling"), Is.True, "السياحى");
      Assert.That(regex.IsMatch("_@Bling"), Is.False, "_@Bling");
    }
