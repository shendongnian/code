    [Test]
    public void isScaleneTest()     
    { 
        var triangle = new Triangle(3.9, 5.0, 2.0); 
        Assert.That(triangle.isIsoceles(), Is.False);
        Assert.That(triangle.isEquilateral(), Is.False);
        Assert.That(triangle.isScalene(), Is.True);
    }
