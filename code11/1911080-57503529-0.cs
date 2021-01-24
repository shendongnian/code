csharp
private void WebView_PermissionRequested(WebView sender, WebViewPermissionRequestedEventArgs args)
{
    if (args.PermissionRequest.PermissionType == WebViewPermissionType.WebNotifications)
    {
        args.PermissionRequest.Allow();
    }
}
You can also pop up a window when you listen for a request, letting the user choose whether to accept the notification.
Best regards.
