    public void Copy()
    {
        int bytesRead;
        while ((bytesRead = _sourceStream.Read(_buffer, 0, _buffer.Length)) > 0)
        {
            _destinationStream.Write(_buffer, 0, bytesRead);
            _completedBytes += bytesRead;
            TriggerProgressUpdate();
            if (someAppropriateCondition)
            {
                _destinationStream.Flush();
            }
        }
    }
