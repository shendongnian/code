    public interface IProcessor
    {         
        ICollection<OutputEntity> Process(ICollection<InputEntity>> entities);
        string SomeField{get;set;}
    }
    
    
    public class Engine
    {
        public Engine(IEnumerable<IProcessor> processors)
        {
            //asign the processors to local variable
        }
    
        public void ProcessRecords(IService service)
        {
            // getRecords code etc.
            foreach(var processor in processors)
            {
                processor.Process(typeRecords.Where(typeRecord => typeRecord.SomeField == processor.SomeField));
            }
        }
    }
