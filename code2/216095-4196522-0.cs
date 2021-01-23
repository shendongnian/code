    [Test]
    public void Test_CannotCreateDuplicateEmail()
    {
       // Arrange
       CreateAccount("test@example.com");   // OK
       
       // Act
       try
       {
          CreateAccount("test@example.com");
          
          // If control arrives here, then the test has failed.
          Assert.Fail();
       }
       // Assert
       catch(AccountException ex)
       {
            // Assert that the correct exception has been thrown.
            Assert.AreEqual("Failed", ex.Message);
       }
    }
