    <code>
protected override void DeserializeElement( XmlReader reader, bool serializeCollectionKey )
{
	XmlDocument document = new XmlDocument();
	document.LoadXml( reader.ReadOuterXml() );
	MyProperty = document.DocumentElement.HasAttribute( "MyProperty" )
		? document.DocumentElement.Attributes[ "MyProperty" ].Value
		: string.Empty;
}
    </code>
