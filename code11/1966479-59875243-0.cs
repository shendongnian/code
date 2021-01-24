using System;
using System.Collections.Generic;
using System.Text;
namespace ContentPageExample
{
    class App
    {
    }
}
Please note that there is no access modifier (`public`, `internal`) on our class. But for classes the default implicit access level is `internal`, i.e. only classes within the same assembly can see this class and create instances of<sup>1</sup>, since `MainActivity` is located in another assembly it is not allowed to access `App`.
You can fix this, by adding an explicit access modifier to `App`
csharp
using System;
using System.Collections.Generic;
using System.Text;
namespace ContentPageExample
{
    public class App
    {
    }
}
<sup>1</sup> *There is an exception: You can add the [`InternalsVisibleToAttribute`][1] to an assembly to allow another assembly to access internal classes and methods, but I'd advise you to use this rarely and definitely not in the present case.*
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.internalsvisibletoattribute?view=netframework-4.8
