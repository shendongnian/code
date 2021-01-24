    // AfterMap Action function that usages context
    public class AfterMapAction : IMappingAction<Source, Destination>
    {
        public void Process(Source source, Destination destination, 
                                           ResolutionContext context)
        {
            destination.Name = context.Items["YourVal"].ToString();
        }
    }
    
    
    //Configuration declaration
    var configuration = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Source, Destination>()
          .AfterMap<AfterMapAction>();
    });
    var mapper = configuration.CreateMapper();    
    //Pass actual parameter value e.g. "ActualName" 
    var result = mapper.Map<Source, Destination>(source, opt => 
                           opt.Items["YourVal"] = "ActualName");
    // The result will have Name as "ActualName".
