cs
// somewhere in your init code
AssemblyLoadContext.Default.Resolving += OnAssemblyResolve;
Assembly OnAssemblyResolve(AssemblyLoadContext assemblyLoadContext, AssemblyName assemblyName)
{
  try
  {
    AssemblyLoadContext.Default.Resolving -= OnAssemblyResolve;
    return assemblyLoadContext.LoadFromAssemblyName(assemblyName);
  }
  catch
  {
    if (assemblyName.Name == "Microsoft.SqlServer.Types")
      return typeof(SqlGeography).Assembly;
    throw;
  }
  finally
  {
    AssemblyLoadContext.Default.Resolving += OnAssemblyResolve;
  }
}
I will update linq2db documentation to mention it and also check if we can improve this situation on our side
