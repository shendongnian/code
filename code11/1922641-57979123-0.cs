public static Task SendAsync (this HubConnection hubConnection, string methodName, params object[] args) {
    return SendAsync(hubConnection, methodName, null, args);
}
public static Task SendAsync (this HubConnection hubConnection, string methodName, CancellationToken cancellationToken, params object[] args) {
    ...
}
That effectively makes the `CancellationToken` optional.
But Microsoft also has the standard of putting the `CancellationToken` as the last parameter in every async method they write. So they would be breaking that pattern if they did this. So they settled on only allowing [10 arguments](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.signalr.client.hubconnectionextensions.sendasync?view=aspnetcore-2.2#Microsoft_AspNetCore_SignalR_Client_HubConnectionExtensions_SendAsync_Microsoft_AspNetCore_SignalR_Client_HubConnection_System_String_System_Object_System_Object_System_Object_System_Object_System_Object_System_Object_System_Object_System_Object_System_Object_System_Object_System_Threading_CancellationToken_).
