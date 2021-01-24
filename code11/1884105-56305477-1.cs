public class AutoMapperEfCarrier : AutoMapper.Profile
{
    public AutoMapperEfCarrier()
    {
        CreateMap<Carrier, CarrierDto>(); // no need to specify Drivers mapping because the property name is the same
        // those below are just examples, use the correct mapping for your class
        // example 1: property mapping
        CreateMap<Driver, Pair<int, string>>()
            .ForMember(p => p.Value, c => c.MapFrom(s => s.Id))
            .ForMember(p => p.Text, c => c.MapFrom(s => s.FirstName + " " + s.LastName));
        // example 2: constructor mapping
        CreateMap<Driver, Pair<int, string>>()
            .ConstructUsing(d=> new Pair<int, string>(d.Id, d.LastName));
    }
}
