    private static byte[] ConvertToP1363Signature(byte[] ASN1Sig)
    {
      AsnParser asn = new AsnParser(ASN1Sig);
      asn.NextSequence();
      byte[] r = asn.NextInteger();
      byte[] s = asn.NextInteger();
      // Returned to caller
      byte[] p1363Signature = new byte[40];
      if (r.Length > 21 || (r.Length == 21 && r[0] != 0))
      {
        // WTF???
        // Reject - signature verification failed
      }
      else if (r.Length == 21)
      {
        // r[0] = 0
        // r[1]'s high bit *should* be set
        Array.Copy(r, 1, p1363Signature, 0, 20);
      }
      else if (r.Length == 20)
      {
        // r[0]'s high bit *should not* be set
        Array.Copy(r, 0, p1363Signature, 0, 20);
      }
      else
      {
        // fewer than 20 bytes
        int len = r.Length;
        int off = 20 - len;
        Array.Copy(r, 0, p1363Signature, off, len);
      }
      if (s.Length > 21 || (s.Length == 21 && s[0] != 0))
      {
        // WTF???
        // Reject - signature verification failed
      }
      else if (s.Length == 21)
      {
        // s[0] = 0
        // s[1]'s high bit *should* be set
        Array.Copy(s, 1, p1363Signature, 20, 20);
      }
      else if (s.Length == 20)
      {
        // s[0]'s high bit *should not* be set
        Array.Copy(s, 0, p1363Signature, 20, 20);
      }
      else
      {
        // fewer than 20 bytes
        int len = s.Length;
        int off = 40 - len;
        Array.Copy(s, 0, p1363Signature, off, len);
      }
      return p1363Signature;
    }
