    bool TryCalculate(out double paramOut)
    {
      try
      {
        // do some calculations
        return true;
      }
      catch(Exception e)
      { 
         // do some handling
        return false;
      }
      
    }
    double calcOutput;
    if(!TryCalc1(inputParam, out calcOutput))
      TryCalc2(inputParam, out calcOutput);
