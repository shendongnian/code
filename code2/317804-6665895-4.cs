     [Test]
     public void ShouldRethrowExceptionWhenCatchBlockIsNotSpecified()
     {
         Assert.Throws<InvalidOperationException>(() =>
             {
                 try
                 {
                     Debug.WriteLine("1");
                     throw new InvalidOperationException("nothing");
                 }
                 finally
                 {
                     Debug.WriteLine("3");
                 }
             });
     }
