    _outputBuffer = ByteBuffer.Allocate(1008 * 4);  // 1008 number of labels
    _floatInBytData = new byte[floatValues.Length * sizeof(float)];
    System.Buffer.BlockCopy(floatValues, 0, _floatInBytData, 0, _floatInBytData.Length);
    using (var bf = ByteBuffer.Wrap(_floatInBytData))
    {
        _outputBuffer.Rewind();
        bf.Rewind();
        _tflite.Run(bf, _outputBuffer);
    }
    float[] outputs = new float[1008];
    byte[] o = new byte[1008 * 4];
    _outputBuffer.Position(0);
    _outputBuffer.Get(o);
    System.Buffer.BlockCopy(o, 0, outputs, 0, o.Length);
