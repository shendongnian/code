    public interface IRepository
    {
       void Add(BusinessObject item);
    }
    
    public sealed class ServiceLayerContext
    {
       private readonly IRepository repository;
    
       public ServiceLayerContext(IRepository repository)
       {
           this.repository = repository;
       }
    
       public void ProcessDto(IDtoObject dto)
       {
           var businessObject = this.CreateBusinessObject(dto);
           this.repository.Add(businessObject);
       }
    
       private BusinessObject CreateBusinessObject(IDtoObject dto)
       {
       }
    }
