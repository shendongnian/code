    var repository = new MyLinq2SqlRepository();
    string typeName = "MyProject.Data.Person";
    var mi = repository.GetType().GetMethod("DeleteRecord");
    var fullyDefinedMethod = mi.MakeGenericMethod(typeof(Type.GetType(typeName));
    object[] parameters = new[] { id };
    fullyDefinedMethod.Invoke(repository, parameters);
