        using (var memoryStream = new MemoryStream())
        {
            using (var reader = new StreamReader(memoryStream))
            {
                foreach (var byteSegment in bytes)
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    await memoryStream.WriteAsync(byteSegment, 0, byteSegment.Length);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    Debug.WriteLine(await reader.ReadToEndAsync());
                }
            }
        }
