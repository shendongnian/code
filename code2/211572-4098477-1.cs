    interface IOperation1
    {
      void Operation1(int x, int y);
    }
    
    interface IOperation2
    {
      void Operation2(string a, string b);
    }
    
    interface IMath
    {
      int Add(int i, int j);
      int Subtract(int i, int j);
      int Multiply(int i, int j);
      int Divide(int i, int j);
    }
    
    interface IStrategy
    {
      //What operations should the Strategy have?
    }
    
    class ClassA : IOperation1, IOperation2, IMath
    {
      public IStrategy CustomStrategy { get; set; }
    
      public void Operation1(int x, int y)
      {
        IOperation1 op1 = CustomStrategy as IOperation1;
        if (op1 != null)
        {
          op1.Operation1(x, y);
        }
        else
        {
          //Do ClassA's Operation1 logic here
        }
      }
    
      public void Operation2(string a, string b)
      {
        IOperation2 op2 = CustomStrategy as IOperation2;
        if (op2 != null)
        {
          op2.Operation2(a, b);
        }
        else
        {
          //Do ClassA's Operation2 logic here
        }
      }
    
      //
      // And so on ...
      //
    }
