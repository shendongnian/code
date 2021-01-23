    public class BusinessLogicAutomapper
    {
        static BusinessLogicAutomapper
        {
            Mapper.CreateMap<Post, PostModel>();
            Mapper.AssertConfigurationIsValid();
        }
    }
