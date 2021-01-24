internal static bool IsPackaged()
{
  try
  {
    // If we have a package ID then we are running in a packaged context
    var dummy = Windows.ApplicationModel.Package.Current.Id;
    return true;
  }
  catch
  {
    return false;
  }
}
(From [this Desktop Bridge sample](https://github.com/microsoft/DesktopBridgeToUWP-Samples/blob/master/Samples/DotNetSatelliteAssemblyDemo/ContosoDemoVsProject/ContosoDemo/PriResourceResolver.cs#L30)).
