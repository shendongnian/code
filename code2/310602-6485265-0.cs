    public byte[] GetImageData(int imageId)
    {
        using (var connection = new SqlConnection(SomeConnectionString))
        using (var command = connection.CreateCommand())
        {
            connection.Open();
            command.CommandText = "SELECT image_data FROM images WHERE image_id = @imageId";
            command.Parameters.AddWithValue("@imageId", imageId);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    const int CHUNK_SIZE = 2 * 1024;
                    byte[] buffer = new byte[CHUNK_SIZE];
                    long bytesRead;
                    long fieldOffset = 0;
                    using (var stream = new MemoryStream())
                    {
                        while ((bytesRead = reader.GetBytes(0, fieldOffset, buffer, 0, buffer.Length)) > 0)
                        {
                            stream.Write(buffer, 0, (int)bytesRead);
                            fieldOffset += bytesRead;
                        }
                        return stream.ToArray();
                    }
                }
            }
        }
        throw new Exception("An image with id=" + imageId + " was not found");
    }
