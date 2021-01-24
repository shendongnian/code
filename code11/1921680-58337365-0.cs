class AppointmentDto {
    public long Id { get; set; }
    public string FullName { get; set; }
    public StoreDto Store { get; set; }
}
class StoreDto {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
}
However to have the expected behavior, you need to change your mappings from:
Mapper.CreateMap<Store, StoreDto>();
Mapper.CreateMap<StoreType, StoreTypeDto>();
to
Mapper.CreateMap<Store, StoreDto>()
   .ForMember(x => x.Value, x => x.MapFrom(store => store.StoreType.Value));
