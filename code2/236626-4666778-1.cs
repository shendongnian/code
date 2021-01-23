    [Test]
    public void AttibuteTest()
    {
       // arrange
       var value = //.. value to test - new Eligability() ;
       var attrib = new EligabilityStudentDebtsAttribute();
    
       // act
       var result = attrib.IsValid(value);
    
       // assert
       Assert.That(result, Is.True)
    }
