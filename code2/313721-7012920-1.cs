    string OID_DATA = "1.2.840.113549.1.7.1";
    // setup the data to sign
    ContentInfo content = new ContentInfo( new Oid( OID_DATA ), manifestSFBytes );
    SignedCms signedCms = new SignedCms( content, true );
    CmsSigner signer = new CmsSigner( SubjectIdentifierType.IssuerAndSerialNumber, cert );
    
    // create the signature
    signedCms.ComputeSignature( signer );
    byte[] data = signedCms.Encode();
