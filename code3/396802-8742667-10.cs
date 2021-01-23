    [Test]
    public void DoublePrecisionRoundingTest()
    {
       double aValue = 1.2345678;
       Assert.That(aValue + double.Epsilon, Is.EqualTo(aValue)); // passes! Should fail
    }
