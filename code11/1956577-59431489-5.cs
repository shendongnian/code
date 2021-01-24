    public class User 
    {
      public string Name { get; set; }
      public string SurName { get; set; }
      public Company Company { get; set; }
      public static implicit operator IdentDto(User u) =>new IdentDto
            {
              User = new UserDto {Name = u.Name, SurName = u.SurName},
              Company = new CompanyDto { ... }
            };
    }
