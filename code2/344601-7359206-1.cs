    /// <summary>
    /// Writes a stream to a file and returns a <see cref="Guid"/> that
    /// can be used to retrieve it again.
    /// </summary>
    /// <param name="incomingFile">The incoming file.</param>
    /// <returns>The <see cref="Guid"/> that should be used to identify the file.</returns>
    public static Guid WriteFile(Stream incomingFile)
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "MyApplication");
        path = Path.Combine(path, "BinaryData");
        var guid = Guid.NewGuid();
        var ba = guid.ToByteArray();
        // Create the path for the GUID.
        path = Path.Combine(ba[0].ToString("x2"));
        path = Path.Combine(ba[1].ToString("x2"));
        path = Path.Combine(ba[2].ToString("x2"));
        Directory.CreateDirectory(path); // Always succeeds, even if the directory already exists.
        path = Path.Combine(guid.ToString() + ".dat");
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            var buffer = new byte[Environment.SystemPageSize];
            var length = 0;
            while ((length = incomingFile.Read(buffer, 0, buffer.Length)) != 0)
                fs.Write(buffer, 0, buffer.Length);
        }
        return guid;
    }
    /// <summary>
    /// Deletes a file created by <see cref="WriteFile"/>.
    /// </summary>
    /// <param name="guid">The original <see cref="Guid"/> that was returned by <see cref="WriteFile"/>.</param>
    public static void DeleteFile(Guid guid)
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "MyApplication");
        path = Path.Combine(path, "BinaryData");
        var ba = guid.ToByteArray();
        // Create the path for the GUID.
        path = Path.Combine(ba[0].ToString("x2"));
        path = Path.Combine(ba[1].ToString("x2"));
        path = Path.Combine(ba[2].ToString("x2"));
        path = Path.Combine(guid.ToString() + ".dat");
        if (File.Exists(path))
            File.Delete(path);
    }
    /// <summary>
    /// Reads the a file that was created by <see cref="WriteFile"/>.
    /// </summary>
    /// <param name="guid">The original <see cref="Guid"/> that was returned by <see cref="WriteFile"/>.</param>
    /// <returns>The stream that can be used to read the file.</returns>
    public static Stream ReadFile(Guid guid)
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "MyApplication");
        path = Path.Combine(path, "BinaryData");
        var ba = guid.ToByteArray();
        // Create the path for the GUID.
        path = Path.Combine(ba[0].ToString("x2"));
        path = Path.Combine(ba[1].ToString("x2"));
        path = Path.Combine(ba[2].ToString("x2"));
        path = Path.Combine(guid.ToString() + ".dat");
        return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
    }
