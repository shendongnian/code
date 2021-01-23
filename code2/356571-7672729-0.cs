    using (GetObjectMetadataResponse response = client.GetObjectMetadata(request))
    {
    	DateTime s3LastModified = response.LastModified;
    	string dest = Path.Combine(@"c:\Temp\", localFileName);
    	DateTime localLastModified = File.GetLastWriteTime(dest);
    	if (!File.Exists(dest) || s3LastModified > localLastModified)
    	{
    		// Use GetObject to download and save file
    	}
    
    }
