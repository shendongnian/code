        public static string GetRegistryContentType(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            // determine extension
            string extension = System.IO.Path.GetExtension(fileName);
            string contentType = null;
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(extension))
            {
                if (key != null)
                {
                    object ct = key.GetValue("Content Type");
                    key.Close();
                    if (ct != null)
                    {
                        contentType = ct as string;
                    }
                }
            }
            if (contentType == null)
            {
                contentType = "application/octet-stream"; // default content type
            }
            return contentType;
        }
