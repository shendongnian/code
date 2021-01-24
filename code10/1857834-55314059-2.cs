    string schema = @"...";
    using (MemoryStream memStream = new MemoryStream(eventHubMessage.GetBytes()))
    {
       memStream.Seek(0, SeekOrigin.Begin);
       Schema writerSchema = Schema.Parse(schema);
       Avro.Specific.SpecificDatumReader<MyModel> r = new Avro.Specific.SpecificDatumReader<MyModel>(writerSchema, writerSchema);
       output = r.Read(null, new Avro.IO.BinaryDecoder(memStream));
    }
