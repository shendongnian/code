    var jsonSerializer = new DataContractJsonSerializer(typeof(DateTime));
    var date = DateTime.UtcNow;
            Console.WriteLine("original date = " + date.ToString("s"));
            using (var stream = new MemoryStream())
            {
                jsonSerializer.WriteObject(stream, date);
                stream.Position = 0;
                var deserializedDate = (DateTime)jsonSerializer.ReadObject(stream);
                Console.WriteLine("deserialized date = " + deserializedDate.ToString("s"));
            }
