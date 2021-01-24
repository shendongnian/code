    public class ExternalServiceSignatureContainer : IExternalSignatureContainer
    {
        public void ModifySigningDictionary(PdfDictionary signDic)
        {
            signDic.Put(PdfName.Filter, PdfName.Adobe_PPKLite);
            signDic.Put(PdfName.SubFilter, PdfName.Adbe_pkcs7_detached);
        }
        public byte[] Sign(Stream data)
        {
            // Call your external signing service to create a CMS signature container
            // for the data in the InputStream
            // Depending on your API to access that service you may either be able to
            // directly call it with the stream
         // return YOUR_SIGNING_API_CALL_FOR_STREAM(data);
            // (or a byte[] generated from the stream contents)
         // return YOUR_SIGNING_API_CALL_FOR_ARRAY(StreamUtil.InputStreamToArray(data));
            // as parameter, or you may first have to hash the data yourself
            // (e.g. as follows) and send your hash to the service.
         // byte[] hash = DigestAlgorithms.Digest(data, DigestAlgorithms.SHA256);
         // return YOUR_SIGNING_API_CALL_FOR_HASH(hash)
            // dummy
            return new byte[0];
        }
    }
