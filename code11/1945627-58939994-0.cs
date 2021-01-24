    public byte[] Read()
    {
        try
        {
            byte[] myReadBuffer = new byte[1024];
            StringBuilder myCompleteMessage = new StringBuilder();
            int numberOfBytesRead = 0;
            var finalByteList = new ArrayList<byte>();
            do
            {
                numberOfBytesRead = mmInStream.Read(myReadBuffer, 0, myReadBuffer.Length);
                finalByteList.AddRange(myReadBuffer)
                myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
            }
            while (mmInStream.IsDataAvailable());
            // here is the final array of bytes
            var finalByteArray = finalByteList.ToArray();
            System.Diagnostics.Debug.WriteLine(myCompleteMessage, "Reading");
        }
        catch (IOException ex)
        {
            System.Diagnostics.Debug.WriteLine("Input stream was disconnected", ex);
        }
        return null;
    }
