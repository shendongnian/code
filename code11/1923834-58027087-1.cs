cs
void Main()
{
	var mapperConfig = 
          new MapperConfiguration(mc => mc.AddProfile<MappingProfile>());
	var mapper = mapperConfig.CreateMapper();
	var notAUser = new Persons { RoleId = 1};
	var isAUser = new Persons { RoleId = 2};
	
	var shouldBeNotAUser = mapper.Map<UserProperties>(notAUser);
	var shouldBeAUser = mapper.Map<UserProperties>(isAUser);
	
	Console.WriteLine(shouldBeNotAUser.IsUser);
	Console.WriteLine(shouldBeAUser.IsUser);
	
}
public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Persons, UserProperties>()
		.ForMember(destination => destination.IsUser, 
                     options => options.MapFrom(src => src.RoleId == 2));
	}
}
class UserProperties
{
	public string DisplayName { get; set; }
	public int Id { get; set; }
	public bool IsUser { get; set; }
	public int NotesCount { get; set; }
}
class Persons
{
	public string DisplayName { get; set; }
	public int Id { get; set; }
	public int RoleId { get; set; }
	public int NotesCount { get; set; }
	public string Notes { get; set; }
	public string Comments { get; set; }
}
Output:
> False<br />
True
