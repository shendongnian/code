    foreach(ICodec codec in file.Properties.Codecs) {
        Mpeg.AudioHeader header = (Mpeg.AudioHeader) codec;
        if(header == null)
            return;
        
        if(header.XingHeader != Mpeg.XingHeader.Unknown) {
            /* CODE HERE */
        }
    
        if(header.VBRIHeader != VBRIHeader.Unknown) {
            /* CODE HERE */
        }
    }
