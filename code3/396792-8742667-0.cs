    [Test]
    public void isIsoscelesTest()     
    { 
        var triangle = new Triangle(5.0, 5.0, 2.0); 
        Assert.That(triangle.isIsoceles(), Is.True);
        Assert.That(triangle.isEqualateral(), Is.False);
        Assert.That(triangle.isScalene(), Is.False);
    }
