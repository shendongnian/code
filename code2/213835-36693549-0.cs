    public int Size
    {
        get 
        { 
            var size = 24;
            // Add size for collections and strings
            size += Cts == null ? 0 : Cts.Count * 4;
            size += Tes == null ? 0 : Tes.Count * 4;
            size += Code == null ? 0 : Code.Length;
            size += Message == null ? 0 : Message.Length;
  
            return size;              
        }
    }
    public byte[] ToBytes(byte[] bytes, ref int index)
    {
        if (index + Size > bytes.Length)
            throw new ArgumentOutOfRangeException("index", "Object does not fit in array");
        // Convert Cts
        // Two bytes length information for each dimension
        GeneratorByteConverter.Include((ushort)(Cts == null ? 0 : Cts.Count), bytes, index);
        index += 2;
        if (Cts != null)
        {
            for(var i = 0; i < Cts.Count; i++)
            {
                var value = Cts[i];
            	value.ToBytes(bytes, ref index);
            }
        }
        // Convert Tes
        // Two bytes length information for each dimension
        GeneratorByteConverter.Include((ushort)(Tes == null ? 0 : Tes.Count), bytes, index);
        index += 2;
        if (Tes != null)
        {
            for(var i = 0; i < Tes.Count; i++)
            {
                var value = Tes[i];
            	value.ToBytes(bytes, ref index);
            }
        }
        // Convert Code
        GeneratorByteConverter.Include(Code, bytes, ref index);
        // Convert Message
        GeneratorByteConverter.Include(Message, bytes, ref index);
        // Convert StartDate
        GeneratorByteConverter.Include(StartDate, bytes, index);
        index += 8;
        // Convert EndDate
        GeneratorByteConverter.Include(EndDate, bytes, index);
        index += 8;
        return bytes;
    }
    public Td FromBytes(byte[] bytes, ref int index)
    {
        // Read Cts
        var ctsLength = BitConverter.ToUInt16(bytes, index);
        index += 2;
        var tempCts = new List<Ct>(ctsLength);
        for (var i = 0; i < ctsLength; i++)
        {
            var value = new Ct().FromBytes(bytes, ref index);
            tempCts.Add(value);
        }
        Cts = tempCts;
        // Read Tes
        var tesLength = BitConverter.ToUInt16(bytes, index);
        index += 2;
        var tempTes = new List<Te>(tesLength);
        for (var i = 0; i < tesLength; i++)
        {
            var value = new Te().FromBytes(bytes, ref index);
            tempTes.Add(value);
        }
        Tes = tempTes;
        // Read Code
        Code = GeneratorByteConverter.GetString(bytes, ref index);
        // Read Message
        Message = GeneratorByteConverter.GetString(bytes, ref index);
        // Read StartDate
        StartDate = BitConverter.ToInt64(bytes, index);
        index += 8;
        // Read EndDate
        EndDate = BitConverter.ToInt64(bytes, index);
        index += 8;
        return this;
    }
