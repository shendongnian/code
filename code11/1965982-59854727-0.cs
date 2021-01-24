    public class OrganizationProfile : Profile
    {
      public OrganizationProfile()
      {
        SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
        DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        //Put your CreateMap... Etc.. here
      }
    }
