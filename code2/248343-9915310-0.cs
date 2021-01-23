    var store = new Pkcs12Store();
    // pairs is IEnumerable<Tuple<X509Certificate, AsymmetricKeyParameter>>
    foreach (var pair in pairs)
    {
        var cn = pair.Item1.SubjectDN
             .GetValueList(X509Name.CN).OfType<string>().Single();
        var certEntry = new X509CertificateEntry(pair.Item1);
        store.SetCertificateEntry(cn, certEntry);
        var keyEntry = new AsymmetricKeyEntry(pair.Item2);
        store.SetKeyEntry("Developer Name", keyEntry, new[] { certEntry });
    }
    store.Save(stream, string.Empty.ToArray(), new SecureRandom());
