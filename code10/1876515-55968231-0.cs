    [Test]
    public void MyTest()
    {
        var service = new Mock<MyClass>();
        var array1 = new MyClass[0];
        var array2 = new MyClass[0];
            
        var value1 = "value1";
        var value2 = "value2";
            
        service.Setup(s => s.MyMethod(It.Is<IEnumerable<MyClass>>(e => e == array1))).Returns(value1);          
        service.Setup(s => s.MyMethod(It.Is<IEnumerable<MyClass>>(e => e == array2))).Returns(value2);
            
        Assert.AreEqual(value1, service.Object.MyMethod(array1));
        Assert.AreEqual(value2, service.Object.MyMethod(array2));
    }
