    <Project Sdk="Microsoft.NET.Sdk.Web">
        <PropertyGroup>
            <TargetFramework>netcoreapp3.0</TargetFramework>
            <AspNetCoreHostingModel>InProcess</AspNetCoreHostingModel>
            <AssemblyName>App</AssemblyName>
            <RootNamespace>App</RootNamespace>
        </PropertyGroup>
    
        <ItemGroup>
            <PackageReference Include="Microsoft.AspNetCore.App" />
            <PackageReference Include="Microsoft.EntityFrameworkCore" Version="3.0.0" />
            <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="3.0.0" />
        </ItemGroup>
    </Project>
