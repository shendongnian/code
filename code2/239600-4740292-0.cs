    /// <summary>
    /// Export a certificate to a PEM format string
    /// </summary>
    /// <param name="cert">The certificate to export</param>
    /// <returns>A PEM encoded string</returns>
    public static string ExportToPEM(X509Certificate cert)
    {
        StringBuilder builder = new StringBuilder();            
        builder.AppendLine("-----BEGIN CERTIFICATE-----");
        builder.AppendLine(Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks));
        builder.AppendLine("-----END CERTIFICATE-----");
        return builder.ToString();
    }
