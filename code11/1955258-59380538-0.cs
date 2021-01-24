xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="System.Linq.Async" Version="4.0.0" />
  </ItemGroup>
</Project>
Code:
csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        IAsyncEnumerable<string> sequence = GetStringsAsync();
        List<string> list = await sequence.ToListAsync();
        Console.WriteLine(list.Count);
    }
    static async IAsyncEnumerable<string> GetStringsAsync()
    {
        yield return "first";
        await Task.Delay(1000);
        yield return "second";
        await Task.Delay(1000);
        yield return "third";
    }
}
