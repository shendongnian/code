    public IEnumerable<PersistedFile> FindByMd5(string md5)
    {
        using (var transaction = this.Session.BeginTransaction())
        {
            var files = this.Session.Query<PersistedFile>().Where(f => f.Md5 == md5).ToList();
            transaction.Commit();
            return files;
        }
    }
