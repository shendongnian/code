      public void SomeMethod()
      {
           SomeObject x = null;
           x.SomeMethod(); // NullReferenceException
           File.Open("SomePath", FileMode.CreateNew); // Any number of File Exceptions potentially
           throw new CustomException();
      };
