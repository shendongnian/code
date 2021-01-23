using (MemoryStream stream = new MemoryStream())
{
    using (XmlWriter writer = XmlWriter.Create(stream))
    {
        message.WriteMessage(writer);
        writer.Flush();
        stream.Position = 0;
    }
}
