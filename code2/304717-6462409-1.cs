    public PersistedFile Save(string filePath)
    {
        using (var fileStream = new FileStream(filePath, FileMode.Open))
        {
            var bytes = MD5.Create().ComputeHash(fileStream);
            using (var transaction = this.Session.BeginTransaction())
            {
                var newFile = new PersistedFile
                {
                    Md5 = BitConverter.ToString(bytes),
                    Path = filePath,
                };
                this.Session.Save(newFile);
                transaction.Commit();
                return newFile;
            }
        }
    }
