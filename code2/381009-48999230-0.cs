    string UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                try
                {
                    string id = string.Empty;
                    var lines = File.ReadAllLines($@"{UserProfile}\AppData\Roaming\Mozilla\Firefox\profiles.ini");
                    foreach (var line in lines)
                    {
                        if (line.Contains("Path=Profiles/"))
                        {
                            var text = line.Replace("Path=Profiles/", "");
                            id = text.Trim();
                        }
                    }
                    Array.ForEach(Directory.GetFiles($@"{UserProfile}\AppData\Local\Mozilla\Firefox\Profiles\{id}\cache2\entries"), File.Delete);
                }
                catch { }
