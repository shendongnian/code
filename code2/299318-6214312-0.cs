        // using System.IO;
        [TestMethod]
        public void WhenFileExists()
        {
            // Create a file
            string existingFilename = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            using (File.Open(existingFilename, FileMode.CreateNew)) { }
            // Check its existence
            Assert.IsTrue(File.Exists(existingFilename));
            // Call method to be tested
            string newFilename = DummyCreateFile(existingFilename);
            // Check filenames are different
            Assert.AreNotEqual<string>(existingFilename, newFilename);
            // Check the new file exists
            Assert.IsTrue(File.Exists(newFilename));
        }
        [TestMethod]
        public void WhenFileDoesNotExist()
        {
            // Get a filename but do not create it yet
            string existingFilename = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            // Check the file does not exist
            Assert.IsFalse(File.Exists(existingFilename));
            // Call method to be tested
            string newFilename = DummyCreateFile(existingFilename);
            // Check the file was created with the filename passed as parameter
            Assert.AreEqual<string>(existingFilename, newFilename);
            // Check the new file exists
            Assert.IsTrue(File.Exists(newFilename));
        }
        private string DummyCreateFile(string filename)
        {
            try
            {
                using (File.Open(filename, FileMode.CreateNew)) { }
                return filename;
            }
            catch
            {
                string newFilename = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                using (File.Open(newFilename, FileMode.CreateNew)) { }
                return newFilename;
            }
        }
