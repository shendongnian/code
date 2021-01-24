public class CustomResolver : IValueResolver<AAA, BBB, int>
{
    public int Resolve(AAA source, BBB destination, int member, ResolutionContext context)
    {
        return destination.ValueA == null ? 3 : 2;
    }
}
var _mapperConfiguration = new MapperConfiguration(cfg =>
{
    cfg.AddCollectionMappers();
    cfg.CreateMap<AAA, BBB>(MemberList.Destination)
    .EqualityComparison((a, b) => a.Id == b.Id)
    .ForMember(dest => dest.Id, src => src.MapFrom(m => m.Id))
    .ForMember(dest => dest.UpdatedOrCreated, src => src.MapFrom<CustomResolver>())
    .ForAllOtherMembers(m => m.Ignore());
});
