    System.IO.MemoryStream blobstream = new System.IO.MemoryStream();
    inputblob.CopyTo(blobstream);            
    blobstream.Position = 0;
    //blobstream.Seek(0, SeekOrigin.Begin);
    blob.Upload(blobstream);
