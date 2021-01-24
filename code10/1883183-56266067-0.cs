    public interface ISomethingService
    {
      IEnumerable<SomeDto> GetSome(/*params*/);
    }
    
    public class SomethingService : ISomethingService
    {
        public SomethingService(SomeDbContext context) 
        { // Init stuff. 
        }
        
        IEnumerable<SomeDto> ISomethingService.GetSome()
        {
           // Get some stuff and return DTOs.
        }
    }
