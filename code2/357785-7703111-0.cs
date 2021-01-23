    // I assume this works for MySqlDataReader too...
    int length = reader.GetBytes(column, 0, null, 0, 0);
    byte[] buffer = new byte[length];
    byte index = 0;
    while (index < length)
    {
        int bytesRead = reader.GetBytes(column, index,
                                        buffer, index, length - index);
        index += bytesRead;
    }
