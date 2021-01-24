    public SKPicture Load(string filename)
    		{
    			using (var stream = File.OpenRead(filename))
    			{
    				return Load(stream);
    			}
    		}
    
    		public SKPicture Load(Stream stream)
    		{
    			using (var reader = XmlReader.Create(stream, xmlReaderSettings, CreateSvgXmlContext()))
    			{
    				return Load(reader);
    			}
    		}
    
    		public SKPicture Load(XmlReader reader)
    		{
    			return Load(XDocument.Load(reader));
    		}
