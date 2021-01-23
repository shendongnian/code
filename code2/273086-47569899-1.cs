        [Test]
        public void IsAbsolutePath()
        {
            // Absolute
            TryIsAbsolutePath(@"C:\dir\file.ext", true);
            TryIsAbsolutePath(@"C:\dir\", true);
            TryIsAbsolutePath(@"C:\dir", true);
            TryIsAbsolutePath(@"C:\", true);
            TryIsAbsolutePath(@"\\unc\share\dir\file.ext", true);
            TryIsAbsolutePath(@"\\unc\share", true);
            // Relative
            TryIsAbsolutePath(@"file.ext", false);
            TryIsAbsolutePath(@"dir\file.ext", false);
            TryIsAbsolutePath(@"\dir\file.ext", false);
            TryIsAbsolutePath(@"C:", false);
            TryIsAbsolutePath(@"C:dir\file.ext", false);
            // Invalid
            TryIsAbsolutePath(null, false, false);
            TryIsAbsolutePath("", false, false);
            TryIsAbsolutePath("   ", false, false);
            TryIsAbsolutePath(@"C:\inv<alid", false, false);
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
