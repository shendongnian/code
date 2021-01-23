    // bytes from db
    byte[] multipleNodes = Encoding.UTF8.GetBytes("<first>..</first><second>..</second><third>..</third>");
    
    using (var ms = new MemoryStream())
    {
        // write opening tag
        byte[] newRoot = Encoding.UTF8.GetBytes("<newRoot>");
        ms.Write(newRoot, 0, newRoot.Length);
    
        ms.Write(multipleNodes, 0, multipleNodes.Length);
    
        // write opening tag
        byte[] closeNewRoot = Encoding.UTF8.GetBytes("</newRoot>");
        ms.Write(closeNewRoot, 0, closeNewRoot.Length);
    
        // reset cursor position before pass it to xmldoc
        ms.Position = 0;
    
        var xml = new XmlDocument();
        xml.Load(ms);
    
        Console.WriteLine(xml.InnerXml);
    }
