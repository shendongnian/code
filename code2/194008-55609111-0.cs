            var fileName = "Mylogs.log";
            var local = Path.Combine(@"C:\TempLogs", fileName);
            var remote = Path.Combine(@"\\servername\c$\Windows\Temp\", fileName);
            WebClient request = new WebClient();
            request.Credentials = new NetworkCredential(@"username", "password");
            if (File.Exists(local))
            {
                File.Delete(local);
                File.Copy(remote, local, true);
            }
            else
            {
                File.Copy(remote, local, true);
            }
