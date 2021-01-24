    public struct Test
    {
       // user-defined conversion from Fraction to double
       public static implicit operator int(Test f)
       {
          return 10;
       }
       public static implicit operator Test(int i)
       {
          return new Test();
       }
       // overload operator *
       public static Test operator +(Test a, Test b)
       {
          return new Test();
       }
    
    }
