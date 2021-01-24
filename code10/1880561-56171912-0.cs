    public override string ToString( )
    {
      var serializer = new DataContractSerializer( this.GetType( ) );
      using ( var stream = new MemoryStream( ) )
      {
        var settings = new XmlWriterSettings( );
        settings.Indent = true;
        var writer = XmlWriter.Create( stream, settings );
        {
          serializer.WriteObject( writer, this );
          writer.Flush( );
        }
        stream.Position = 0;
        var reader = new StreamReader( stream );
        return reader.ReadToEnd( );
      }
    }
