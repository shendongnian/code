    static float[] ConvertByteArrayToFloat(byte[] bytes)
    {
        if(bytes.Length % 4 != 0) throw new ArgumentException();
        
        float[] floats = new float[bytes.Length/4];
        for(int i = 0; i < floats.Length; i++)
        {
            floats[i] = BitConverter.ToSingle(bytes, i*4);
        }
    
        return floats;
    }
