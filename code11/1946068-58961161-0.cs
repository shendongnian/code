csharp
public class DataService<T> : IDataService<T>
{
  private readonly IMapper _mapper;
  private Dictionary<RepoTypes, dynamic> _dict;
  public DataService(IRepository<ClassX> xRepository,
                     IRepository<ClassY> yRepository,
                     IRepository<ClassZ> zRepository,
                     IMapper mapper)
  {
    _mapper = mapper;
    _dict = new Dictionary<RepoTypes, dynamic>
    {
      { RepoTypes.X, xRepository },
      { RepoTypes.Y, yRepository },
      { RepoTypes.Z, zRepository }
    };
  }
  public async Task<T> Get(RepoTypes repoType)
  {
    var repo = _dict[repoType];
    var data = await repo.Get();
    return _mapper.Map<T>(data);
  }
}
Because of the type differences between the different `IRepository` interfaces, there's no other way of specifying the dictionary besides: `Dictionary<RepoTypes, dynamic>`.
