    public interface ISomeService
        {
            string GetTheName(IPersonService personService);
        }
        public class SomeService : ISomeService
        {
    
            public string GetTheName(IPersonService personService)
            {
                return personService.Name;
            }
        }
