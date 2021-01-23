    /// <summary>
    /// Initializes a new instance of SevenZipExtractor class.
    /// </summary>
    /// <param name="archiveFullName">The archive full file name.</param>
    /// <param name="password">Password for an encrypted archive.</param>
    public SevenZipExtractor(string archiveFullName, string password)
        : base(password)
    {
        Init(archiveFullName);
    }
