    [Test]
    public void IsFullPath()
    {
        bool isWindows = Environment.OSVersion.Platform.ToString().StartsWith("Win"); // .NET Framework
        // bool isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows); // .NET Core
        // These are full paths on Windows, but not on Linux
        TryIsFullPath(@"C:\dir\file.ext", isWindows);
        TryIsFullPath(@"C:\dir\", isWindows);
        TryIsFullPath(@"C:\dir", isWindows);
        TryIsFullPath(@"C:\", isWindows);
        TryIsFullPath(@"\\unc\share\dir\file.ext", isWindows);
        TryIsFullPath(@"\\unc\share", isWindows);
        // These are full paths on Linux, but not on Windows
        TryIsFullPath(@"/some/file", !isWindows);
        TryIsFullPath(@"/dir", !isWindows);
        TryIsFullPath(@"/", !isWindows);
        // Not full paths on either Windows or Linux
        TryIsFullPath(@"file.ext", false);
        TryIsFullPath(@"dir\file.ext", false);
        TryIsFullPath(@"\dir\file.ext", false);
        TryIsFullPath(@"C:", false);
        TryIsFullPath(@"C:dir\file.ext", false);
        TryIsFullPath(@"\dir", false); // An "absolute", but not "full" path
        // Invalid on both Windows and Linux
        TryIsFullPath(null, false, false);
        TryIsFullPath("", false, false);
        TryIsFullPath("   ", false, false);
        TryIsFullPath(@"C:\inval|d", false, false);
        TryIsFullPath(@"\\is_this_a_dir_or_a_hostname", false, false);
    }
    private static void TryIsFullPath(string path, bool expectedIsFull, bool expectedIsValid = true)
    {
        Assert.AreEqual(expectedIsFull, PathUtils.IsFullPath(path), "IsFullPath('" + path + "')");
        if (expectedIsFull)
        {
            Assert.AreEqual(path, Path.GetFullPath(path));
        }
        else if (expectedIsValid)
        {
            Assert.AreNotEqual(path, Path.GetFullPath(path));
        }
        else
        {
            Assert.That(() => Path.GetFullPath(path), Throws.Exception);
        }
    }
