    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    
    public static string Run(Person person, ILogger log)
    {   
        return person.Name != null
            ? (ActionResult)new OkObjectResult($"Hello, {person.Name}")
            : new BadRequestObjectResult("Please pass an instance of Person.");
    }
    
    public class Person {
         public string Name {get; set;}
    }
