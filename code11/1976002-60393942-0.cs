    public Certificate getLongestLastingCertificate(Certificate[] certs)
    {
        Certificate longetsLastingCert = null;
        if (certs != null)
        {
            if (certs.Count > 0)
            {
                List<Certificate> certSortedList = certs.OrderByDescending(o => o.GetExpirationDate()).ToList();
                longetsLastingCert = certSortedList[0];
            }
        }
        return longetsLastingCert;
    }
