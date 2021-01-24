        private bool Consume(byte[] fileByteArray, IDataProcess dataConsumer)
        {
            try
            {
                using (var conn = OpenConnection())
                {
					// Convert byte Array to a stream
					Stream stream = new MemoryStream(fileByteArray);
					// Create a reader from the stream
					using (var reader = new CsvReader(stream, false, System.Text.Encoding.UTF8))
					{
						RecordEnumerator enumerator = reader.GetEnumerator();
						enumerator.MoveNext();
						do
						{
							// Proccess enumerator.Current with dataConsumer
						} while (enumerator.MoveNext());
					}
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
