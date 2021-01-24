    class TestMessageProcessor : IMessageProcessor
    {
        public Enums.MessageOpcodes Opcode => Enums.MessageOpcodes.TestMessage;
        public void DeserializeAndProcess(byte[] data)
        {
            // Deserialize into a TestMessage
            // Process
        }
    }
