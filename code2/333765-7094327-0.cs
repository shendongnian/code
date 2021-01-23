    class NMessage {
        
        byte[] buffer;
        
        //ctor to create a new message for sending.
        public NMessage(int nSize) {
             buffer = new byte[nSize];
             Buffer.BlockCopy(BitConverter.GetBytes(nSize), 0, buffer, 0, sizeof(UInt32));
        }
        
        //ctor to create msg from received data.
        publix NMessage(byte[] buffer) {
            this.buffer = buffer;
        }
     
        public UInt32 MessageId {
            get { return BitConverter.ToUInt32(buffer, 4);
            set { Buffer.BlockCopy(BitConverter.GetBytes(value), 0, buffer, 4, sizeof(UInt32)); }
        }
        
        ...        
        public Byte MessageId2 {
            get { return buffer[6]; }
            set { buffer[6] = value; }
        }
        
        ...
        
        public UInt32 Size {
            get { return BitConverter.ToUInt32(buffer, 0) }
        }
        
        public Byte[] Buffer {
            get { return buffer; }
        }
    }
---
    class LoginMessage : NMessage {
        
        public LoginMessage() : base(16 + 16) {
            this.MessageId = CTRL_SESSION_LOGIN;
        }
        
        public LoginMessage(NMessage message) : base(message.Buffer) {
        }
        
        public string User {
            get { return encoding.GetString(buffer, 8, 16); }
            set { Buffer.BlockCopy(encoding.GetBytes(value), 0, buffer, 8, 16);
        }
        
        public string Pass {
            get { return encoding.GetString(buffer, 24, 16); }
            set { Buffer.BlockCopy(encoding.GetBytes(value), 0, buffer, 24, 16);
        } 
     }
