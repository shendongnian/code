    public interface A
    {
      void Display();
    }
    
    public interface B : A
    {
      void SomeOtherMethod();
    }
    class Program: B
    {
      public void Display()
      {
        // implementation
      }
      public void SomeOtherMethod()
      {
        // implementation
      }
    }
