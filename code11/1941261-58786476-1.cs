c#
public class BranchProfile : Profile
{
    public BranchProfile()
    {
        CreateMap<Branch, BranchEditViewModel>()
            .AfterMap<MapOnlyForMasterUserAction>();;
    }
}
**IMappingAction:**
c#
public class MapOnlyForMasterUserAction : IMappingAction<BranchEditViewModel, Branch>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public MapOnlyForMasterUserAction(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }
    public void Process(BranchEditViewModel source, Branch destination, ResolutionContext context)
    {
        if (_httpContextAccessor.HttpContext.User.IsInRole(IdentityEnums.UserRoles.Master.ToString()))
        {
            destination.Lock = source.Lock.ToString();
            destination.ExpireOn = source.ExpireOn.ToShortDateString();
        }
        else 
        {
            destination.Lock = destination.Lock;
            destination.ExpireOn = destination.ExpireOn;
        }
    }
}
