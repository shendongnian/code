    public class SCSI_ADDRESS
    {   
        public uint Length;     // 4 bytes, (uint in C# == ulong in C++)
        public byte PortNumber; // 1 byte
        public byte PathId;     // 1 byte
        public byte TargetId;   // 1 byte
        public byte Lun;        // 1 byte
                                // Total: 8 bytes
    }
    // 256 / sizeof(SCSI_ADDRESS) == 256 / 8 == 32
    public SCSI_ADDRESS[] inquiry_data = new byte[256 / sizeof(SCSI_ADDRESS)];
    sa = inquiry_data[0];
