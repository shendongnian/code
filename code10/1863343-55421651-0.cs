    // Including my setup of the range values this time:
        var range = Request.Headers.Range;
        long chunkLength = 2500000;
        long? beginRange = range.Ranges.First().From;
        long? endRange = range.Ranges.First().To;
        if (endRange == null)
        {
            if ((beginRange + chunkLength) > myBlob.Properties.Length)
            {
                endRange = myBlob.Properties.Length - 1;
            }
            else
            {
                endRange = beginRange + chunkLength;
            }
        }
        var blobStreamPosition = beginRange.Value;
    // Set the stream position
        blobStream.Position = blobStreamPosition;
        int bytesToRead = (int)(endRange - blobStreamPosition + 1);
    // Using BinaryReader for convenience
        BinaryReader binaryReader = new BinaryReader(blobStream);
        byte[] blobByteArray = binaryReader.ReadBytes(bytesToRead);
        message.Content = new ByteArrayContent(blobByteArray);
    // Don't forget that now you have to set the content range header yourself:
        message.Content.Headers.ContentRange = new ContentRangeHeaderValue(blobStreamPosition, endRange.Value, myBlob.Properties.Length);
        message.Content.Headers.ContentType = new MediaTypeHeaderValue(myBlob.Properties.ContentType);
        binaryReader.Dispose();
        blobStream.Dispose();
