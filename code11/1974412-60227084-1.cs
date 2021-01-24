csharp
public class VehicleMapping : Profile
{
	public VehicleMapping()
	{
		CreateMap<Vehicle, VehicleDto>()
			.ForMember(x => x.TestDtos, opt => opt.MapFrom(src => src.TestModels))			
			.ReverseMap();
		CreateMap<TestModel, TestDto>().ReverseMap();
	}
}
