    [AspNetCompatibilityRequirements(RequirementsMode =AspNetCompatibilityRequirementsMode.Required)]
    public class CalculatorService : ICalculatorService
    {
        public double Add(double a, double b)
        {
          HttpContext context=  HttpContext.Current;
          string dir =  Directory.GetCurrentDirectory();
            return a + b;
        }
    }
