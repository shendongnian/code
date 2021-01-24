c#
public class CaseInsensitiveComparer : IComparer<string> 
{ 
    public int Compare(string a, string b) 
    { 
        return string.Compare(a, b, StringComparison.OrdinalIgnoreCase); 
    } 
}
[EnableQuery(HandleNullPropagation = HandleNullPropagationOption.False)]
[ODataRoute]
[AuthorizeScopes(AppScopes.FarmerListRead)]
[HttpGet]
public IQueryable<FarmerViewDto> GetAll()
{
    return _unitOfWork
        .FarmerViewRepository
        .GetAllQueryable()
        .UseAsDataSource()
        .For<FarmerViewDto>();
        .OrderBy(x => x.firstName, new CaseInsensitiveComparer());
}
