    <Project Sdk="Microsoft.NET.Sdk.Web">
      <PropertyGroup>
        <TargetFramework>netcoreapp2.1</TargetFramework>
        <GeneratePackageOnBuild>false</GeneratePackageOnBuild>
        <!-- Fix for "System.InvalidOperationException: Cannot find compilation library location for package 'Microsoft.AspNet.WebApi.Client'" -->
        <MvcRazorExcludeRefAssembliesFromPublish>false</MvcRazorExcludeRefAssembliesFromPublish>
      </PropertyGroup>
      <!-- ... -->
     <Project>
