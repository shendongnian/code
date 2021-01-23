            foreach (string resource in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (resource.EndsWith("Snippet.htm"))
                {
                    Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
                    byte[] buff = new byte[s.Length];
                    s.Read(buff, 0, buff.Length);
                    string snippet = Encoding.UTF8.GetString(buff);
                }
            }
