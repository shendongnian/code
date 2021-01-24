using System;
using System.IO;
using System.Collections.Generic;
#if netcore
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
#else
using System.Web;
#endif
If the src project is "compiled" by the Omnisharp server using net472, it will import `System.Web.HttpContext`.  The demo-core project in Controllers/FoalaApiController.cs compiled for netcore2.0 instead references `Microsoft.AspNetCore.Http.HttpContext`.  These obviously don't match.
Had Omnisharp selected the proper netcore2.0 target for the src project, then these would have matched.  It didn't so you see these errors reported by Omnisharp.  You don't see these errors from dotnet build or VS2019 because they properly resolve the correct target framework for the src project.
--- 
Here's what I first experienced when I downloaded the source.  It's not clear what .NET Core SDK version you're using.  When I build the source I see the following error with .NET Core SDK 2.2.100.
> error NU1003: PackageTargetFallback and AssetTargetFallback cannot be used together. Remove PackageTargetFallback(deprecated) references from the project environment.
The fix for this error is simple: remove the `PackageTargetFallback` declaration from the .csproj files.  After this, the project compiles without errors / warnings using `dotnet build`.
I didn't see any other errors in VS Code initially because I too did not have the .NET SDK 4.7.1 targeting pack installed. Consequently, Omnisharp could only compile the src project using netstandard2.0.
