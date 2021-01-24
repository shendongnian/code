    public static void Main(string[] args)
    {
    	var path = @"c:\temp\fileName.zip";
    	byte[] zipBytes = Convert.FromBase64String("YXNkYWRwdWJsaWMgc3RhdGljIHZvaWQgTWFpbihzdHJpbmdbXSBhcmdzKQp7CiAg");
    
    	using (FileStream zip = new FileStream(path, FileMode.Create))
    	{
    		using (ZipArchive archive = new ZipArchive(zip, ZipArchiveMode.Update))
    		{
    			ZipArchiveEntry entry = archive.CreateEntry("base64x.txt");
    			using (var writer = new BinaryWriter(entry.Open()))
    			{
    				writer.Write(zipBytes);
    			}
    		}
    	}
    }
