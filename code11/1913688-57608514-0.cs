    public void Dispose()
    {
        this.table_.Close();
        GC.SuppressFinalize(this);
    }
