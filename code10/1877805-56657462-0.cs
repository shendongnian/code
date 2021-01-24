    DPUruNet.Compression.
    DPUruNet.Compression.SetWsqBitrate(75, 0);
    Fid ISOFid = captureResult.Data;
    
    byte[] paddedImage = PadImage8BPP(captureResult.Data.Views[0].RawImage, captureResult.Data.Views[0].Width, captureResult.Data.Views[0].Height, 512, 512, 255);
    byte[] bytesWSQ512 = Compression.CompressRaw(512, 512, 500, 8, paddedImage, CompressionAlgorithm.COMPRESSION_WSQ_NIST);
