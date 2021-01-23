    byte[] appendBuffers(List<byte[]> arrays)
    {
    	using (PdfDocument document = new PdfDocument())
    	{
    		for (int i = 0; i < arrays.Count; i++)
    			document.Append(arrays[i]);
    
    		using (MemoryStream ms = new MemoryStream())
    		{
    			document.Save(ms);
    			return ms.ToArray();
    		}
    	}
    }
