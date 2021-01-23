        [Test]
        public void IsAbsolutePath()
        {
            bool isWindows = Environment.OSVersion.Platform.ToString().StartsWith("Win"); // .NET Framework
            // bool isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows); // .NET Core
            // These are absolute paths on Windows, but not on Linux
            TryIsAbsolutePath(@"C:\dir\file.ext", isWindows);
            TryIsAbsolutePath(@"C:\dir\", isWindows);
            TryIsAbsolutePath(@"C:\dir", isWindows);
            TryIsAbsolutePath(@"C:\", isWindows);
            TryIsAbsolutePath(@"\\unc\share\dir\file.ext", isWindows);
            TryIsAbsolutePath(@"\\unc\share", isWindows);
            // These are absolute paths on Linux, but not on Windows
            TryIsAbsolutePath(@"/some/file", !isWindows);
            TryIsAbsolutePath(@"/dir", !isWindows);
            TryIsAbsolutePath(@"/", !isWindows);
            // Relative on both Windows and Linux
            TryIsAbsolutePath(@"file.ext", false);
            TryIsAbsolutePath(@"dir\file.ext", false);
            TryIsAbsolutePath(@"\dir\file.ext", false);
            TryIsAbsolutePath(@"C:", false);
            TryIsAbsolutePath(@"C:dir\file.ext", false);
            // Invalid on both Windows and Linux
            TryIsAbsolutePath(null, false, false);
            TryIsAbsolutePath("", false, false);
            TryIsAbsolutePath("   ", false, false);
            TryIsAbsolutePath(@"C:\inval|d", false, false);
        }
        private static void TryIsAbsolutePath(string path, bool expectedIsAbsolute, bool expectedIsValid = true)
        {
            Assert.AreEqual(expectedIsAbsolute, PathUtils.IsAbsolutePath(path), "IsAbsolutePath('" + path + "')");
            if (expectedIsAbsolute)
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
