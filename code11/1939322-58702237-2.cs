c#
// simplyfied
var referencePaths = ApplicationPartManager.ApplicationParts
	.OfType<ICompilationReferencesProvider>()
	.SelectMany(_ => _.GetReferencePaths())
which uses:
[ApplicationPartManager.ApplicationParts](https://github.com/aspnet/AspNetCore/blob/200c9e21bdeaa6257d3f617b06e28f6d1bf42c69/src/Mvc/Mvc.Core/src/ApplicationParts/ApplicationPartManager.cs#L31)
**So we need somehow register our own `ICompilationReferencesProvider` and this is how..**
## ApplicationPartManager
While it's search for Application parts does the `ApplicationPartManager` a few things:
1. it searchs for hidden Assemblies reading attributes like:
c#
[assembly: ApplicationPartAttribute(assemblyName:"..")] // Specifies an assembly to be added as an ApplicationPart
[assembly: RelatedAssemblyAttribute(assemblyFileName:"..")] // Specifies a assembly to load as part of MVC's assembly discovery mechanism.
// plus `Assembly.GetEntryAssembly()` gets added automaticly behind the scenes.
2. Then it loops throuth all found Assemblies and uses [ApplicationPartFactory.GetApplicationPartFactory](https://github.com/aspnet/AspNetCore/blob/200c9e21bdeaa6257d3f617b06e28f6d1bf42c69/src/Mvc/Mvc.Core/src/ApplicationParts/ApplicationPartFactory.cs#L37)(assembly) ([as seen in line 69](https://github.com/aspnet/AspNetCore/blob/200c9e21bdeaa6257d3f617b06e28f6d1bf42c69/src/Mvc/Mvc.Core/src/ApplicationParts/ApplicationPartManager.cs#L69)) to find types which extend `ApplicationPartFactory`.
3. Then it invokes the method `GetApplicationParts(assembly)` on all found `ApplicationPartFactory`s.
_All Assemblies without `ApplicationPartFactory` get the `DefaultApplicationPartFactory` which returns `new AssemblyPart(assembly)` in `GetApplicationParts`._
c#
public abstract IEnumerable<ApplicationPart> GetApplicationParts(Assembly assembly);
## GetApplicationPartFactory
GetApplicationPartFactory searches for `[assembly: ProvideApplicationPartFactory(typeof(SomeType))]` then it uses `SomeType` as factory.
c#
public abstract class ApplicationPartFactory {
	public abstract IEnumerable<ApplicationPart> GetApplicationParts(Assembly assembly);
	public static ApplicationPartFactory GetApplicationPartFactory(Assembly assembly)
    {
        // ...
        var provideAttribute = assembly.GetCustomAttribute<ProvideApplicationPartFactoryAttribute>();
        if (provideAttribute == null)
        {
            return DefaultApplicationPartFactory.Instance; // this registers `assembly` as `new AssemblyPart(assembly)`
        }
        var type = provideAttribute.GetFactoryType();
        // ...
        return (ApplicationPartFactory)Activator.CreateInstance(type);
    }
}
## One Solution
This means we can create and register (using `ProvideApplicationPartFactoryAttribute`) our own `ApplicationPartFactory` which returns a custom `ApplicationPart` implementation which implements `ICompilationReferencesProvider` and then returns our references in `GetReferencePaths`.
c#
[assembly: ProvideApplicationPartFactory(typeof(MyApplicationPartFactory))]
namespace WebApplication1 {
    public class MyApplicationPartFactory : ApplicationPartFactory {
        public override IEnumerable<ApplicationPart> GetApplicationParts(Assembly assembly)
        {
            yield return new CompilationReferencesProviderAssemblyPart(assembly);
        }
    }
    public class CompilationReferencesProviderAssemblyPart : AssemblyPart, ICompilationReferencesProvider {
        private readonly Assembly _assembly;
        public CompilationReferencesProviderAssemblyPart(Assembly assembly) : base(assembly)
        {
            _assembly = assembly;
        }
        public IEnumerable<string> GetReferencePaths()
        {
        	// your `LoadPrivateBinAssemblies()` method needs to be called before the next line executes!
        	// So you should load all private bin's before the first RazorPage gets requested.
            return AssemblyLoadContext.GetLoadContext(_assembly).Assemblies
                .Where(_ => !_.IsDynamic)
                .Select(_ => new Uri(_.CodeBase).LocalPath);
        }
    }
}
## My Working Test Setup:
 * ASP.NET Core 3 WebApplication
 * ASP.NET Core 3 ClassLibrary
 * Both Projects have **no reference** to each other.
xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>netcoreapp3.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <Content Remove="Pages\**" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation" Version="3.0.0" />
  </ItemGroup>
</Project>
c#
services
   .AddRazorPages()
   .AddRazorRuntimeCompilation();
AssemblyLoadContext.Default.LoadFromAssemblyPath(@"C:\path\to\ClassLibrary1.dll");
// plus the MyApplicationPartFactory and attribute from above.
~/Pages/Index.cshtml
razor
@page
    output: [
        @(
            new ClassLibrary1.Class1().Method1()
        )
    ]
And it shows the expected output:
    output: [ 
        Hallo, World!
    ]
Have a nice day.
