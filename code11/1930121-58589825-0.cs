     public static bool VerifySignature(string fileName, Stream inputStream, Stream keyIn)
        {
            PgpPublicKeyRingBundle pgpPubRingCollection = new PgpPublicKeyRingBundle(keyIn);
            PgpPublicKey pubicKey = pgpPubRingCollection.GetPublicKey(4100000000000000000);    //once I knew the right one, I put it here directly as it won't change anyway
            Stream signaturStrom = PgpUtilities.GetDecoderStream(inputStream);
            PgpObjectFactory pgpWTFactory = new PgpObjectFactory(signaturStrom);
            PgpSignature signtr = ((PgpSignatureList)pgpWTFactory.NextPgpObject())[0];
            signtr.InitVerify(pubicKey);
            try
            {
                Stream dIn = ReadStream(fileName);  // get stream from ext. file
                int ch;
                while ((ch = dIn.ReadByte()) >= 0)
                {
                    signtr.Update((byte)ch);
                }
                dIn.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            if (signtr.Verify())
            {
                Console.WriteLine("signature verified.");
                return true;
            }
            else
            {
                Console.WriteLine("signature verification failed.");
                return false;
            }
        }
