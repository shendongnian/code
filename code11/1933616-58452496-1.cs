    <Project Sdk="Microsoft.NET.Sdk">
      <PropertyGroup>
        <TargetFramework>netcoreapp2.2</TargetFramework>
        <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
      </PropertyGroup>
    
      <ItemGroup>
        <PackageReference Include="MSBuildTasks" Version="1.5.0.235">
          <PrivateAssets>all</PrivateAssets>
          <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        </PackageReference>
        <PackageReference Include="System.Data.DataSetExtensions" Version="4.5.0" />
      </ItemGroup>
    
      <ItemGroup>
        <Reference Include="Microsoft.AspNetCore.Http.Abstractions">
          <HintPath>C:\Program Files\dotnet\sdk\NuGetFallbackFolder\microsoft.aspnetcore.http.abstractions\2.2.0\lib\netstandard2.0\Microsoft.AspNetCore.Http.Abstractions.dll</HintPath>
        </Reference>
      </ItemGroup>
    
      <Import Project="../.build/build.proj" />
    </Project
