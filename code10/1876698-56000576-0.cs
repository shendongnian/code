    TextWriter textWriter = new StringWriter();
    PemWriter pemWriter = new PemWriter(textWriter);
    pemWriter.WriteObject(publicKey);
    pemWriter.Writer.Flush();
    String publicKeyPEM = textWriter.ToString();
