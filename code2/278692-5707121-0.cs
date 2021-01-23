    public void WriteFrameCodesAsBinary(IEnumerable<int> frameCodes)
    {
        using (FileStream fileStream = new FileStream(binaryFilePath,  FileMode.Create))
        using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
        {
        	foreach (int frameCode in frameCodes) {
        		binaryWriter.Write(frameCode);
        	}
        }
    }
    
