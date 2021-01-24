    class DictionaryContent: HttpContent
    {
       public Object Value { get; }
       public DictionaryContent( Object value)
       {
           Value = value;
           Headers.ContentType = .. You must provide the desired content type.
       }
       protected override Task SerializeToStreamAsync( Stream stream, TransportContext context )
       {
            using ( var buffer = new BufferStreamWriter( stream, 4096 ) )
            {
                var writer = new JsonWriter( buffer, JsonSettings.Default );
                writer.WriteValue( Value ); // HERE You can do anything that you want.
            }
            return Task.CompletedTask;
       }
    }
