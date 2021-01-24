csharp
using System;
using System.Reflection;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
//somewhere in your code
private static readonly MethodInfo mapperMethodInfo = 
    typeof(HubRouteBuilder).GetMethod(
        "MapHub",
        new Type [] { 
            typeof(PathString),
            typeof(Action<HttpConnectionDispatcherOptions>)
        },
        null
    );
// in your mapping code
// replace this:
Application.UseSignalR(R => R.MapHub<H>(Route));  
// with this
Application.UseSignalR(R => 
{
   // pay attention to use of H.Type, R and Route variables
   mapperMethodInfo.MakeGenericMethod(H.Type).Invoke(R, new object [] { Route });
});
