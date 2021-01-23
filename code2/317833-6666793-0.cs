    interface IValidator <T>
    {
      bool Validate (T value);
    }
    class IntValidator : IValidator <int>
    {
      public bool Validate (int value)
      {
        return value > 10 && value < 15;
      }
    }
    class Int2Validator : IValidator<int>
    {
      public bool Validate (int value)
      {
        return value > 100 && value < 150;
      }
    }
  
    struct Property<T, P> where P : IValidator<T>, new ()
    {
      public T Value
      {
        set
        {
          if (m_validator.Validate (value))
          {
            m_value = value;
          }
          else
          {
            Console.WriteLine ("Error validating: '" + value + "' is out of range.");
          }
        }
      
        get { return m_value; }
      }
      T m_value;
      static IValidator<T> m_validator=new P();
    }
    class Program
    {
      static void Main (string [] args)
      {
        Program
          p = new Program ();
        p.m_p1.Value = 9;
        p.m_p1.Value = 12;
        p.m_p1.Value = 25;
        p.m_p2.Value = 90;
        p.m_p2.Value = 120;
        p.m_p2.Value = 250;
      }
      Property<int, IntValidator>
        m_p1;
      Property<int, Int2Validator>
        m_p2;
    }
