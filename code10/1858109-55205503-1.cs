    [Fact] // This will pass
    public void MockFunc_IsAny_RetursResult()
    {
    	var expectedOutput = 2;
    
    	var repo = new MockRepository(MockBehavior.Strict);
    	var function = repo.FixedFunc(It.IsAny<object>(), expectedOutput);
    
    	var output = function(It.IsAny<object>());
    
    	Assert.Equal(expectedOutput, output);
    	repo.VerifyAll();
    }
