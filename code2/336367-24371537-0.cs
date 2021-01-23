    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ assembly name="$(SolutionDir)\Domain\bin\Debug\Domain.dll" #>
    <#@ import namespace="System.Linq" #>
    <#@ output extension=".cs" #>
    using System.Runtime.CompilerServices;
    <#
     var publicType = typeof(Domain.Foo);
     var allTypes = publicType.Assembly.GetTypes();
    
     var entityType = allTypes.Single(t => t.FullName == "Domain.Entities.Entity"); // my entity supertype
            
     foreach(var type in allTypes.Where(t => !t.IsAbstract && entityType.IsAssignableFrom(t)))
    {#>
    [assembly: InternalsVisibleTo("<#= type.Name #>ProxyAssembly")]
    <#}#>
