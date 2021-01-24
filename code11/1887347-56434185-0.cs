public void Migrate (string targetMigration = null);
(https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.migrations.imigrator.migrate)
**Update: added example**
*MigrationContext.cs*
public class MigrationContext : DbContext
{
}
*Execute migrations*
using (var tenantContext = new MigrationContext())
{
	tenantContext.Database.GetService<IMigrator>().Migrate("targetMigration");
}
*.csproj file*
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.2</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="2.2.4" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.2.4" />
  </ItemGroup>
</Project>
