    TextWriter textWriter = new StringWriter();
    PemWriter pemWriter = new PemWriter(textWriter);
    pemWriter.WriteObject(keys.Private);
    pemWriter.Writer.Flush();
    string privateKey = pemWriter.ToString();
