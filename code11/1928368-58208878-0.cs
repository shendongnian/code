    [SecurityCritical]
    private static void InternalWriteAllText(
      string path,
      string contents,
      Encoding encoding,
      bool checkHost)
    {
      using (StreamWriter streamWriter = new StreamWriter(path, false, encoding, 1024, checkHost))
        streamWriter.Write(contents);
    }
