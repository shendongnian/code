    var path = @"path/to/doc.docx";
    
    byte[] byteArray = File.ReadAllBytes(path);
    
    using (MemoryStream stream = new MemoryStream())
    {
    	stream.Write(byteArray, 0, (int)byteArray.Length);
    	using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, true))
    	{
    		Body body = wordDoc.MainDocumentPart.Document.Body;
       		foreach (var text in body.Descendants<Text>())
    		{    			
    			text.Text = text.Text.Replace("BBB", "CCC!");
    		}
       		wordDoc.Close();
       	}
    	File.WriteAllBytes(path+".mod.docx", stream.ToArray());
    }
