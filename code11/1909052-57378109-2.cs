C#
private IJob CreateJob(string nameSpace, string jobName)
{
    //  This part is unclear: It sounds like you're loading assemblies from files dynamically, 
    //  but it's not clear how you locate them. This assumes the assembly names are the same 
    //  as the namespace, and they're all in a directory called "jobs"
    var assemblyPath = $"jobs\\{nameSpace}.dll";
    return (IJob)Assembly.LoadFile(assemblyPath).CreateInstance($"{nameSpace}.{jobName}");
}
If the jobs are all in assemblies that are already linked, it's even easier:
C#
private IJob CreateJob(string nameSpace, string jobName)
{
    return (IJob)Activator.CreateInstance(Type.GetType($"{nameSpace}.{jobName}"));
}
