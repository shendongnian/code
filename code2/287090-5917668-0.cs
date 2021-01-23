    public static byte[] Compress( byte[] data )
    {
    	var output = new MemoryStream();
    	using ( var gzip = new GZipStream( output, CompressionMode.Compress, true ) )
    	{
    		gzip.Write( data, 0, data.Length );
    		gzip.Close();
    	}
    	return output.ToArray();
    }
