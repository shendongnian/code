    using (X509Certificate2 cert = req.Create(
        root,
        DateTimeOffset.UtcNow.AddDays(-1),
        DateTimeOffset.UtcNow.AddDays(90),
        new byte[] { 1, 2, 3, 4, 5, 6 }))
    {
        using (X509Certificate2 certWithKey = cert.CopyWithPrivateKey(rsa))
        {
            ...
        }
    }
