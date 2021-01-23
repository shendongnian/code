        [TestMethod]
        public void RemoveDriveFromPath()
        {
            string path = @"C:\test.txt";
            Assert.AreEqual("test.txt", System.Text.RegularExpressions.Regex.Replace(path, @"^[A-Z]\:\\", string.Empty));
        }
