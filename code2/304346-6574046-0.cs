    public void SignFile(String fileName, 
                         Stream privateKeyStream,
                         String privateKeyPassword,                      
                         Stream outStream)
    {
        PgpSecretKey pgpSec = ReadSigningSecretKey(privateKeyStream);
        PgpPrivateKey pgpPrivKey = null;
        pgpPrivKey = pgpSec.ExtractPrivateKey(privateKeyPassword.ToCharArray());
        PgpSignatureGenerator sGen = new PgpSignatureGenerator(pgpSec.PublicKey.Algorithm, KeyStore.ParseHashAlgorithm(this.hash.ToString()));
        sGen.InitSign(PgpSignature.BinaryDocument, pgpPrivKey);
        foreach (string userId in pgpSec.PublicKey.GetUserIds()) {
            PgpSignatureSubpacketGenerator spGen = new PgpSignatureSubpacketGenerator();
            spGen.SetSignerUserId(false, userId);
            sGen.SetHashedSubpackets(spGen.Generate());
        }
        CompressionAlgorithmTag compression = PreferredCompression(pgpSec.PublicKey);
        PgpCompressedDataGenerator cGen = new PgpCompressedDataGenerator(compression);
        BcpgOutputStream bOut = new BcpgOutputStream(cGen.Open(outStream));
        sGen.GenerateOnePassVersion(false).Encode(bOut);
        FileInfo file = new FileInfo(fileName);
        FileStream fIn = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        PgpLiteralDataGenerator lGen = new PgpLiteralDataGenerator();
        Stream lOut = lGen.Open(bOut, PgpLiteralData.Binary, file);
        
        int ch = 0;
        while ((ch = fIn.ReadByte()) >= 0) {
            lOut.WriteByte((byte)ch);
            sGen.Update((byte) ch);
        }
        fIn.Close();
        sGen.Generate().Encode(bOut);
        lGen.Close();
        cGen.Close();
        outStream.Close();
    }
    public PgpSecretKey ReadSigningSecretKey(Stream inStream)
    // throws IOException, PGPException, WrongPrivateKeyException
    {        
        PgpSecretKeyRingBundle pgpSec = CreatePgpSecretKeyRingBundle(inStream);
        PgpSecretKey key = null;
        IEnumerator rIt = pgpSec.GetKeyRings().GetEnumerator();
        while (key == null && rIt.MoveNext())
        {
            PgpSecretKeyRing kRing = (PgpSecretKeyRing)rIt.Current;
            IEnumerator kIt = kRing.GetSecretKeys().GetEnumerator();
            while (key == null && kIt.MoveNext()) 
            {
                PgpSecretKey k = (PgpSecretKey)kIt.Current;
                if(k.IsSigningKey)
                    key = k;
            }
        }
        if(key == null)
          throw new WrongPrivateKeyException("Can't find signing key in key ring.");
        else
            return key;
    }
