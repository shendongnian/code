var farmerViewDto = _unitOfWork
        .FarmerViewRepository
        .GetAllQueryable()
        .UseAsDataSource()
        .For<FarmerViewDto>();
var returnValue = farmerViewDto.ToList().OrderBy(x => x.PropertyYouWantToSort, StringComparer.OrdinalIgnoreCase).AsQueryable();
retur returnValue;
adding additional information on my comment
var searchFilter = //user input
var query = _unitOfWork
        .FarmerViewRepository
        .GetAllQueryable()
        .UseAsDataSource()
        .For<FarmerViewDto>().AsQueryable();
if (searchFilter == "property1")
{
    query = query.OrdberBy(x => x.Property1, StringComparer.OrdinalIgnoreCase).AsQueryable();
}
if (searchFilter == "property2")
{
    query = query.OrdberBy(x => x.Property2, StringComparer.OrdinalIgnoreCase).AsQueryable();
}
.....
return query;
