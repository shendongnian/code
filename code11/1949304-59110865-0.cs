lang-c#
// You can use Assembly.GetExecutingAssembly() if the models are in the same assembly this code runs from
var assembly = typeof(SomeTypeInAssembly).Assembly;
var modelTypes = assembly.GetTypes()
    .Where(t => t.IsClass && t.Namespace == "Namespace.For.Your.Models");
foreach (var modelType in modelTypes)
{
    services.AddScoped<IGenericRepository<modelType>, GenericRepository<modelType>>();
}
Where `SomeTypeInAssembly` is a type in the same assembly where your models live, and `"Namespace.For.Your.Models"` is the full namespace your models are in.
