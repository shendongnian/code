        public Task<byte[]> Serialize<TData>(TData data)
            where TData : class
        {
            using (var buffer = new MemoryStream())
            {
                // Serialize the data.
                var avroSerializer = Microsoft.Hadoop.Avro.AvroSerializer.Create<TData>(_settings);
                
                avroSerializer.Serialize(buffer, data);
 
                // Return the contents of the buffer.
                buffer.Seek(0, SeekOrigin.Begin);
                return Task.FromResult(buffer.ToArray());
            }
        }
