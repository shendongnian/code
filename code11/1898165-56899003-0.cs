using (var writer = new XmlTextWriter(file, new UTF8Encoding(false)))
{
    writer.Formatting = Formatting.Indented;
    xdoc.Save(writer);
}
