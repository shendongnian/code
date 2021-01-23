    internal class SomeCalculationResult 
    { 
         internal double? Result { get; private set; } 
         internal Exception Exception { get; private set; }
    }
    ...
    SomeCalculationResult calcResult = Calc1();
    if (!calcResult.Result.HasValue) calcResult = Calc2();
    if (!calcResult.Result.HasValue) calcResult = Calc3();
    if (!calcResult.Result.HasValue) throw new NoCalcsWorkedException();
    // do work with calcResult.Result.Value
    ...
