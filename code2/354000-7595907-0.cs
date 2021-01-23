    using (var response = request.GetResponse())
    {
        using (var stream = response.GetResponseStream())
        {
            // Just read the data and throw it away
            byte[] buffer = new byte[16 * 1024];
            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                // Ignore the actual data
            }
        }
    }
