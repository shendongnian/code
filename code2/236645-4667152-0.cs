try
{
  // load the assembly or type
}
catch (Exception ex)
{
  if (ex is System.Reflection.ReflectionTypeLoadException)
  {
    var typeLoadException = ex as ReflectionTypeLoadException;
    var loaderExceptions  = typeLoadEx.LoaderExceptions;
  }
}
