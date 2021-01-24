    var opCode = (Enums.MessageOpcodes)(data[0] << 8 | data[1]);
    switch (opCode)
    {
        case Enums.MessageOpcodes.TestMessage:
            ProcessTestMessage(data);
            break;
        case Enums.MessageOpcodes.VectorMessage:
            ProcessVectorMessage(data);
            break;        
    }
