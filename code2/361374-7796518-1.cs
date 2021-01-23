    private double calcStuff()
    {
      try { return calc1(); }
      catch (Calc1Exception e1)
      {
        // Continue on to the code below
      }
      try { return calc2(); }
      catch (Calc2Exception e1)
      {
        // Continue on to the code below
      }
      try { return calc3(); }
      catch (Calc3Exception e1)
      {
        // Continue on to the code below
      }
      throw new NoCalcsWorkedException();
    }
