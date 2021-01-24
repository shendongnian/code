    [TestMethod]
        public void FileExists()
        {
            Assembly a = Assembly.LoadFrom(@"..\..\..\WebApplicationProject\bin\WebApplicationProject.dll");
            string t = string.Join("", a.GetManifestResourceNames());
            Assert.IsTrue(t.Contains("file.*"));
        }
