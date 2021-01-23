    public IfxBlob CreateIfxBlob(byte[] data)
    {
        //Get the connection however you like and make sure it's open...
        //Obviously you should make this method handle exceptions and the such.
        
        IfxBlob blob = connection.GetIfxBlob();
        
        blob.Open(IfxSmartLOBOpenMode.ReadWrite);
        blob.Write(data);
        blob.Close();
        return blob;
    }
