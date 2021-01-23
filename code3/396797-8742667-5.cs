    [Test]
    public void isEquilateralTest()     
    { 
        var triangle = new Triangle(3.9, 3.9, 3.9); 
        Assert.That(triangle.isIsoceles(), Is.False);
        Assert.That(triangle.isEqualateral(), Is.True);
        Assert.That(triangle.isScalene(), Is.False);
    }
