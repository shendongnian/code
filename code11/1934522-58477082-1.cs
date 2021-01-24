cs
 _Departments.Add(
     new DepartmentEntity()
     {
         Id = DepartmentId,
         Department = "Bitte ändern"
     });
It allows UI to understand, that `Departments` property was updated.
You can also think about getting rid of this code in `Departments` getter
cs
var container = ContainerConfig.Configure();
using (var scope = container.BeginLifetimeScope())
{
      var test = scope.Resolve<IDepartmentRepository>();
      _Departments = test.GetAll().ToObservable();
}
since you already added new item to `_Departments` backing field
