cs
public class MyMappingProfile : Profile
{
    public MyMappingProfile()
    {
        string departmentName = "Foo";
        CreateMap<Company, MyDto>()
            .ForMember(m => m.DepartmentLocation, opt => opt.MapFrom(SelectDepartment(departmentName)));
    }
    private Expression<Func<Company, string>> SelectDepartment(string departmentName)
        => (company) => company.Divisions
            .SelectMany(division => division.Departments)
            .Where(department => department.Name == departmentName)
            .FirstOrDefault()
            .Location;
}
EF Core will generate nice query:
sql
SELECT(
    SELECT TOP(1) [d0].[Name]
    FROM [Division] AS[d]
          INNER JOIN [Department] AS [d0] ON [d].[Id] = [d0].[DivisionId]
    WHERE ([c].[Id] = [d].[CompanyId]) 
        AND ([d0].[Name] = @__departmentName_0)) 
    AS [DepartmentLocation]
FROM [Company] AS[c]
Usage:
cs
var result = dbContext
    .Set<Company>()
    .ProjectTo<MyDto>(mapperConfiguration)
    .ToList();
result.ForEach(myDto =>
{
    if (myDto.DepartmentLocation == null)
    {
        throw new AutoMapperMappingException("Department was not found!");
    }
});
