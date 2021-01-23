    public void WriteList<T>(List<T> value) where T:IBinarySerializable
    {
        for (int i = 0; i < value.Count; i++)
        {
            _writer.Write(value[i].GetBytes());
        }
    }
