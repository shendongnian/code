 c#
// brain.cs
namespace Brain {
   public class A {
      public B InstanceOfB { get; set;}
   }
   public class B { }
}
This will still work if the two classes are in separate files, so the above is the same as:
 c#
/// brain.A.cs
namespace Brain {
   public class A {
      public B InstanceOfB { get; set;}
   }
}
/// brain.B.cs
namespace Brain {
   public class B { }
}
Ultimately you just need to add the using statement for the namespace they use in their code when adding the files to your project (`using Brain;` for the example above). 
**Default Namespaces edit:**
Default namespaces are set for classes that don't specify this in the code file. You can find the default namespace (called `RootNamespace`) in the `*.csproj` files in a `<PropertyGroup>` in the `<Project>` element (usually it's the first PropertyGroup in the file):
xml
<!-- Brain.Common.csproj -->
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  ...
  <PropertyGroup>
    ...
    <RootNamespace>Brain.Common</RootNamespace>
    <AssemblyName>Brain.Common</AssemblyName>
    ...
    
