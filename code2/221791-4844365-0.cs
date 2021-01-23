    <code>
public class ConfigurationSectionReader<T> where T : ConfigurationSection, new()
{
	public T GetSection( string sectionXml ) 
	{
		T section = new T();
		using ( StringReader stringReader = new StringReader( sectionXml ) )
		using ( XmlReader reader = XmlReader.Create( stringReader, new XmlReaderSettings() { CloseInput = true } ) )
		{
			reader.Read();
			section.GetType().GetMethod( "DeserializeElement", BindingFlags.NonPublic | BindingFlags.Instance ).Invoke( section, new object[] { reader, true } );
		}
		return section;
	}
}
    </code>
