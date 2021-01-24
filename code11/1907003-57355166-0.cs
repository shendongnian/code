    public static Encoding GetFileEncoding(GitRepository repository, GitItem gitItem)
        {
            GitVersionDescriptor versionDesc = !string.IsNullOrEmpty(Configuration.Branch) ? new GitVersionDescriptor()
            {
                VersionType = GitVersionType.Branch,
                Version = Configuration.Branch,
                VersionOptions = GitVersionOptions.None
            } : null;
            using (Stream stream = GitClient.GetItemContentAsync(repository.Id, gitItem.Path, download: false, versionDescriptor: versionDesc, includeContentMetadata: true, includeContent: true).Result)
            {
                var bom = new byte[4];
                stream.Read(bom, 0, 4);
                // Analyze the BOM
                if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
                if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
                if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
                if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
                if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
                using (StreamReader reader = new StreamReader(stream, true))
                {
                    reader.Peek();
                    if (reader.ReadToEnd().Contains('�'))
                    {
                        return Encoding.ASCII;
                    }
                    return Encoding.UTF8;
                }
            }
