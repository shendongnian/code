      public void ShowPhoto(String uri, String username, String password)
            {
                WebClient ftpClient = new WebClient();
                ftpClient.Credentials = new NetworkCredential(username,password);
                byte[] imageByte = ftpClient.DownloadData(uri);
    
    
                var tempFileName = Path.GetTempFileName();
                System.IO.File.WriteAllBytes(tempFileName, imageByte);
    
                string path = Environment.GetFolderPath(
                    Environment.SpecialFolder.ProgramFiles);
    
                // create our startup process and argument
                var psi = new ProcessStartInfo(
                    "rundll32.exe",
                    String.Format(
                        "\"{0}{1}\", ImageView_Fullscreen {2}",
                        Environment.Is64BitOperatingSystem ?
                            path.Replace(" (x86)", "") :
                            path
                            ,
                        @"\Windows Photo Viewer\PhotoViewer.dll",
                        tempFileName)
                    );
    
                psi.UseShellExecute = false;
    
                var viewer = Process.Start(psi);
                // cleanup when done...
                viewer.EnableRaisingEvents = true;
                viewer.Exited += (o, args) =>
                {
                    File.Delete(tempFileName);
                };
    
    
            }
