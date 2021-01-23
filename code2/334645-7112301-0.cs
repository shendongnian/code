    String content = Encoding.UTF8.GetString(certContent);
    String base64Content = content.Replace("-----BEGIN CERTIFICATE-----", "").Replace("-----END CERTIFICATE-----", "").Replace("\r", "").Replace("\n", "");
    byte[] decodedContent = Convert.FromBase64String(base64Content);
    SignedCms certContainer = new SignedCms();
    certContainer.Decode(decodedContent);
