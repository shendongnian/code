try
{
    PackageInfo pInfo = PackageManager.GetPackageInfo(PackageName, 0);
    var version = pInfo.VersionName;
    if (Version.TryParse(version, out Version result))
    {
        AuthenticationManager.Instance.AppVersion = result;
    }
    else
        AuthenticationManager.Instance.AppVersion = new Version(4, 13, 17);
    Console.WriteLine("Version Name : " + version);
}
catch (PackageManager.NameNotFoundException ex)
{
    Console.WriteLine("NameNotFoundException: " + ex.Message);
    AuthenticationManager.Instance.AppVersion = new Version(4, 13, 17);
}
