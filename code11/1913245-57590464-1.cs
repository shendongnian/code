    Document document = new Document();
    PdfWriter writer = PdfWriter.GetInstance(document, output);
    ...
    byte[] bytes = new byte[1024];
    for (int i = 0; i < bytes.Length; i++)
        bytes[i] = (byte)(0x0a);
    writer.Os.Write(bytes, 0, bytes.Length);
