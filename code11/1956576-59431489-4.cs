    public static class UserExtensions
    {
      public static IdentDto ToIdentDto(this User u)
      {
        return new IdentDto
        {
          User = new UserDto {Name = u.Name, SurName = u.SurName},
          Company = u.Company.ToCompanyDto()
        }
      }
    }
    public static class CompanyExtensions
    {
      public static CompanyDto ToCompanyDto(this Company c)
      {
        ...
      }
    }
