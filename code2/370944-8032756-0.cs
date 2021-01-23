    uint[] uintArray;
    
    //I need to convert from uint[] to byte[]
    byte[] byteArray = new byte[uintArray.Length * sizeof(uint)];
    for (int i = 0; i < uintArray.Length; i++)
    {
        byte[] barray = System.BitConverter.GetBytes(uintArray[i]);
        for (int j = 0; j < barray.Length; j++)
        {
              byteArray[i * sizeof(uint) + j] = barray[j];
        }
    }
    cmd.Parameters.Add("@myBindaryData", SqlDbType.Binary).Value = byteArray;
