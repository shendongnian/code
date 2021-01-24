    public class SetTimestampMappingAction: IMappingAction<object, MyBaseObject>
    {
        public SetTraceIdentifierAction(/*if you are using dependency injection use it here*/)
        {
    
        }
    
        public void Process(SomeModel source, SomeOtherModel destination, ResolutionContext context)
        {
            destination.xxxxxx = DateTimeHelper.GetCurrentUTCDateTime()
    
        }
    }
    
    public class SomeProfile : Profile
    {
        public SomeProfile()
        {
            CreateMap<object, MyBaseObject>()
                .AfterMap<SetTimestampMappingAction>();
        }
    }
