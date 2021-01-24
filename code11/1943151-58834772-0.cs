    try
    {
        Int32 docCount = documents.Count;
        MemoryStream[] streams = null;
        using (ZipFile zip = new ZipFile(outputdirectory))
        {
            if (docCount == 1)
            {
                string invoiceNumber = documents[0].GetElementsByTagName("InvoiceNumber")[0].InnerText + ".xml";
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = Encoding.GetEncoding("UTF-8");
                SaveFiles(documents[0], invoiceNumber, settings);
                resultValue = InvoiceResult.Success;
            }
            else
            {
                streams = new MemoryStream[docCount]
                for (Int32 i = 0; i < docCount; ++i)
                {
                    var doc = documents[i];
                    string invoiceNumber = doc.GetElementsByTagName("InvoiceNumber")[0].InnerText + ".xml";
                    MemoryStream str = new MemoryStream();
                    streams[i] = str;
                    document.Save(str);
                    str.Seek(0, SeekOrigin.Begin);
                    zip.AddEntry($"{invoiceNumber}.xml", str);
                }
                zip.Save();
            }
        }
        if (streams != null)
            for (Int32 i = 0; i < docCount; ++i)
                if (streams[i] != null)
                    streams[i].Dispose();        
    }
    catch (Exception)
    {
        resultValue = InvoiceResult.CannotCreateZipFile;
    }
