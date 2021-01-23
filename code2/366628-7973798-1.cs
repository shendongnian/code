        using System.IO.IsolatedStorage;
        using ICSharpCode.SharpZipLib.Zip;
        using ICSharpCode.SharpZipLib.Core;
        using System.Text;
        // Recurses down the folder structure
        //
        private void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset, IsolatedStorageFile isf)
        {
            string[] files = isf.GetFileNames(System.IO.Path.Combine(path, "*.*"));
            foreach (string filename in files)
            {
                string filenameWithPath = System.IO.Path.Combine(path, filename);
                string entryName = filenameWithPath.Substring(folderOffset); // Makes the name in zip based on the folder
                entryName = ZipEntry.CleanName(entryName); // Removes drive from name and fixes slash direction
                ZipEntry newEntry = new ZipEntry(entryName);
                newEntry.DateTime = isf.GetLastWriteTime(filenameWithPath).DateTime; // Note the zip format stores 2 second granularity
                // To permit the zip to be unpacked by built-in extractor in WinXP and Server2003, WinZip 8, Java, and other older code,
                // you need to do one of the following: Specify UseZip64.Off, or set the Size.
                // If the file may be bigger than 4GB, or you do not need WinXP built-in compatibility, you do not need either,
                // but the zip will be in Zip64 format which not all utilities can understand.
                //   zipStream.UseZip64 = UseZip64.Off;
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(filenameWithPath, System.IO.FileMode.Open, isf))
                {
                    newEntry.Size = stream.Length;
                }
                zipStream.PutNextEntry(newEntry);
                // Zip the file in buffered chunks
                // the "using" will close the stream even if an exception occurs
                byte[] buffer = new byte[4096];
                using (IsolatedStorageFileStream streamReader = isf.OpenFile(filenameWithPath, System.IO.FileMode.Open))
                {
                    StreamUtils.Copy(streamReader, zipStream, buffer);
                }
                zipStream.CloseEntry();
            }
            string[] folders = isf.GetDirectoryNames(System.IO.Path.Combine(path, "*.*"));
            foreach (string folder in folders)
            {
                CompressFolder(System.IO.Path.Combine(path, folder), zipStream, folderOffset, isf);
            }
        }
        // Compresses the files in the nominated folder, and creates a zip file on disk named as outPathname.
        //
        public void CreateZip(string outPathname, string password, string folderName)
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream fsOut = new IsolatedStorageFileStream(outPathname, System.IO.FileMode.Create, isf))
                {
                    ZipOutputStream zipStream = new ZipOutputStream(fsOut);
                    zipStream.SetLevel(3); //0-9, 9 being the highest level of compression
                    zipStream.Password = password;	// optional. Null is the same as not setting.
                    // This setting will strip the leading part of the folder path in the entries, to
                    // make the entries relative to the starting folder.
                    // To include the full path for each entry up to the drive root, assign folderOffset = 0.
                    
                    // int folderOffset = folderName.Length + (folderName.EndsWith("\\") ? 0 : 1); // hu: currently not used for WP7 sample
                    int folderOffset = 0;
                    CompressFolder(folderName, zipStream, folderOffset, isf);
                    zipStream.Close();
                }
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                isf.CreateDirectory(@"root");
                isf.CreateDirectory(@"root\subfolder1");
                isf.CreateDirectory(@"root\subfolder2");
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(@"root\file0.txt", System.IO.FileMode.Create, isf))
                {
                    byte[] bytes = Encoding.Unicode.GetBytes("hello");
                    stream.Write(bytes, 0, bytes.Length);
                }
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(@"root\subfolder1\file1.txt", System.IO.FileMode.Create, isf))
                {
                    byte[] bytes = Encoding.Unicode.GetBytes("zip");
                    stream.Write(bytes, 0, bytes.Length);
                }
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(@"root\subfolder2\file2.txt", System.IO.FileMode.Create, isf))
                {
                    byte[] bytes = Encoding.Unicode.GetBytes("world");
                    stream.Write(bytes, 0, bytes.Length);
                }
                                
            }
            CreateZip("root.zip", null, "root");
        }
