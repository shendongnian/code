    public class ElectricEngine : EngineBase
    {
         public override Refuel(IRefuelParameters parameters)
         {
              if(!(parameters is ElectricParameters))
                  throw ApplicationException("Not the right params!");
              ElectricParameters rightParams = parameters as ElectricParameters;
         }
    }
