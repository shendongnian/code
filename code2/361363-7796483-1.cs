    bool TryCalculate(Param param, out Param)
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
    var calcOutput;
    if(!TryCalc1(inputParam, out calcOutput))
      TryCalc2(inputParam, out calcOutput);
