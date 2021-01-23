    CoderPropID[] propIDs = 
    {
        CoderPropID.DictionarySize,
        CoderPropID.PosStateBits,
        CoderPropID.LitContextBits,
        CoderPropID.LitPosBits,
        CoderPropID.Algorithm,
        CoderPropID.NumFastBytes,
        CoderPropID.MatchFinder,
        CoderPropID.EndMarker
    };
    object[] properties = 
    {
        (Int32)(dictionary),
        (Int32)(posStateBits),
        (Int32)(litContextBits),
        (Int32)(litPosBits),
        (Int32)(algorithm),
        (Int32)(numFastBytes),
        mf,
        eos
    };
    Compression.LZMA.Encoder encoder = new Compression.LZMA.Encoder();
    encoder.SetCoderProperties(propIDs, properties);
    encoder.WriteCoderProperties(outStream);
    if (trainStream != null)
    {
        CDoubleStream doubleStream = new CDoubleStream();
        doubleStream.s1 = trainStream;
        doubleStream.s2 = inStream;
        doubleStream.fileIndex = 0;
        inStream = doubleStream;
        long trainFileSize = trainStream.Length;
        doubleStream.skipSize = 0;
        if (trainFileSize > dictionary)
            doubleStream.skipSize = trainFileSize - dictionary;
        trainStream.Seek(doubleStream.skipSize, SeekOrigin.Begin);
        encoder.SetTrainSize((uint)(trainFileSize - doubleStream.skipSize));
    }
    encoder.Code(inStream, outStream, -1, -1, null);
