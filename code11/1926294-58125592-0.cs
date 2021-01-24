    [Test]
    public void ComplexNumberTest()
    {
         ComplexNumber result = SomeCalculation();
         Assert.Multiple(() =>
         {
             Assert.AreEqual(5.2, result.RealPart, "Real part");
             Assert.AreEqual(3.9, result.ImaginaryPart, "Imaginary part");
         });
    }
