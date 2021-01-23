    using (SerialPort serialPort)
    {
        try
        {
            serialPort.PortName = portNames[i];
            serialPort.Open();
            isOpen[i] = true;
            // You could call serialPort.Close() here if you want. It's really not needed, though, since the using block will dispose for you (which in turn will close)
        }
        catch (Exception ex)
        {
            // I would refactor this, but that's your call
            if (ex is InvalidOperationException || ex is UnauthorizedAccessException || ex is IOException)
            {
                // port unavailable
                isOpen[i] = false;
            }
            else
            {
                throw;    // Don't eat the exception if it wasn't what you were looking for
            }
        }
    }
