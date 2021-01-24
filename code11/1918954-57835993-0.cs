C#
@using System.Net.Http
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Authentication
@using Microsoft.AspNetCore.Components.Authorization
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Rendering
@using Microsoft.AspNetCore.Components.RenderTree
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using Microsoft.JSInterop
@using NeighborHub
@using NeighborHub.Shared
@using NeighborHub.Data //Cause of the error
So I went ahead and delete 
C#
@using NeighborHub.Data
Somehow this seems to fix everything.
Why? I'm entirely not sure why this @using Namespace.Data statement caused the error.
