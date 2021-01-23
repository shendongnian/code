    public class UserMappingProfile : Profile
    {
      // Props
      public override string ProfileName { get { return "UserMappingProfile"; } }
      
      // Methods
      public override void Configure()
      {
        CreateMap<User, Dictionary<string, string>>().ConvertUsing<DictionaryTypeConverter>();
        base.Configure();
      }
      
      // Types
      internal class DictionaryTypeConverter : ITypeConverter<User, Dictionary<string, string>>
      {
        public User Convert(ResolutionContext context)
        {
          var dict = context.SourceValue as Dictionary<string, string>;
          if (dict == null)
            return null;
            
          return new User() { Name = dict["Name"], Age = dict["Age"] };
        }
      }
    }
