    CommandDataPacket msg = new CommandDataPacket
     {
     Address = 0x12,
     Command = 0x45,
     Data = new byte[] { 0x03, 0x05, 0x07 }
     }
    byte[] rawMessage = msg.ToBytes();
