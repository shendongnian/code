csharp
public class VehicleMapping : Profile
{
	public VehicleMapping()
	{
		CreateMap<Vehicle, VehicleDto>()
			.ForMember(x => x.TestDtos, opt => opt.MapFrom(src => src.TestModels))
			.ForMember(x => x.AboutYouTitle, opt => opt.MapFrom(src => src.AboutYou.Title))
			.ReverseMap();
		CreateMap<TestModel, TestDto>().ReverseMap();
	}
}
