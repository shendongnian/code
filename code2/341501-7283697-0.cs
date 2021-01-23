           ...
           if (this.IsDirectory())
           {
              OpenFileWith("explorer.exe", this.FullPath, "/root,");
           }
           else
           {
              OpenFileWith("explorer.exe", this.FullPath, "/select,");
           }
          ...
        public static void OpenFileWith(string exePath, string path, string arguments)
        {
            if (path == null)
                return;
            
            try 
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
                if (exePath != null)
                {
                    process.StartInfo.FileName = exePath;
                    //Pre-post insert quotes for fileNames with spaces.
                    process.StartInfo.Arguments = string.Format("{0}\"{1}\"", arguments, path);
                }
                else
                {
                    process.StartInfo.FileName = path;
                    process.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
                }
                if (!path.Equals(process.StartInfo.WorkingDirectory))
                {
                    process.Start();
                }
            }
            catch(System.ComponentModel.Win32Exception ex) 
            {
                FormManager.DisplayException(ex, MessageBoxIcon.Information);
            }
        }
