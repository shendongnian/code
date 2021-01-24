    interface IMessageProcessor
    {
        Enums.MessageOpcodes Opcode { get; }
        void DeserializeAndProcess(byte[] data);
    }
