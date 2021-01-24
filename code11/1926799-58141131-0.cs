<Project Sdk="Microsoft.NET.Sdk.WindowsDesktop">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.0</TargetFramework>
    <UseWPF>true</UseWPF>
    <ApplicationIcon />
    <StartupObject>ProjectName.App</StartupObject>
  </PropertyGroup>
  <ItemGroup>
    <Page Include="App.xaml"></Page>
  </ItemGroup>
  <ItemGroup>
    <ApplicationDefinition Remove="App.xaml"></ApplicationDefinition>      <--- key part
  </ItemGroup>
  
</Project>
I checked the .csproj file for a working .NET Framework project, and the key seems to be removing App.xaml as ApplicationDefinition by hand, as the .NET Framework .csproj did not have that section in it.
