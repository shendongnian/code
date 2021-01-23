    XElement xe = ...;
    using(StreamWriter sw = new StreamWriter(new MemoryStream()))
    {
      sw.Write(xe.ToString());
      sw.Flush();
      sw.BaseStream.Seek(0, SeekOrigin.Begin);
      OpenXmlReader re = OpenXmlReader.Create(sw.BaseStream);
      re.Read();
      OpenXmlElement oxe = re.LoadCurrentElement();
      re.Close();
    }
