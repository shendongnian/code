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
## However
Your mapping configuration code should not have to 'know' about what RoleID indicates a user. Your `Person` class should be where that knowledge is held, so that should have either an `IsUser()` method or a get-only `IsUser` property (with the `NotMapped` attribute) which returns `RoleId == 2`: in the former case you would still need `ForMember` but in the latter case you wouldn't, though if you _do_ map back from `UserProperties` to `Persons` you would need something there to handle it - again, this should be in the `Persons` class and not in the mapper config. Maybe `SetAsUser()` that sets the RoleId.
