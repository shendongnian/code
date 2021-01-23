    [Test]
    public void MyMethod_DodgyStuffDone_ThrowsRulesException() {
        // arrange
        var myObject = CreateObject();
        Exception caughtException = null;
        // act
        try {
            myObject.DoDodgyStuff();
        }
        catch (Exception ex) {
            caughtException = ex;
        }
        // assert
        Assert.That(caughtException, Is.Not.Null);
        Assert.That(caughtException, Is.TypeOf<RulesException>());
        Assert.That(caughtException.Message, Is.EqualTo("My Error Message"));
    }
