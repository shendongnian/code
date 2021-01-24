    string path = @"c:\NewFolder";
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
                path += @"\Log.txt";
                if (!File.Exists(path))
                {
                    var strFile = File.Create(path);
                    File.SetAttributes(path, FileAttributes.Normal);
                    strFile.Close();
                }
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    string texto = string.Empty;
                    texto += "\n Date: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm");
                    sw.WriteLine(texto);
                    sw.Close();
                }
