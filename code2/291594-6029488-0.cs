    public interface IProcessor
    {         
        ICollection<OutputEntity> Process(ICollection<InputEntity>> entities);
    }
    
    [Processor("Type1")]
    public class Processor1 : IProcessor
    {
    }
    
    [Processor("Type2")]
    public class Processor1 : IProcessor
    {
    }
    
    public class Engine
    {
      Dictionary<string, IProcessor> processors;
    
      public Engine()
      {
         // use reflection to check the types marked with ProcessorAttribute and that implement IProcessor
         // put them in the processors dictionary
         // RegisterService(type, processor);
      }
    
      public RegisterService(string type, IProcessor processor)
      {
        processor[type] = processor;
      }
    
      public void ProcessRecords(IService service)
      {  
         var records = service.GetRecords();  
         foreach(var kvp in processors)
         {
            kvp.Value.Process(records.Where(record => record.SomeField == kvp.Key));
         }
      }  
    }
