    public unsafe struct SSP_FULL_KEY
    {
        System.Int64 FixedKey;
        System.Int64 EncryptKey;
        public SSP_FULL_KEY(System.Int64 fix, System.Int64 encr)
        {
            FixedKey = fix;
            EncryptKey = encr;
        }
    }
    public unsafe struct SSP_COMMAND
    {
        //string PortNumber; 
        SSP_FULL_KEY key;
        System.Int32 BaudRate; // baud rate of the packet 
        System.Int32 Timeout; // how long in ms to wait for a reply from the slave 
        char PortNumber; // the serial com port number of the host 
        char SSPAddress; // the SSP address of the slave 
        char RetryLevel; // how many retries to the slave for non-response 
        char EncryptionStatus; // is this an encrypted command 0 - No, 1 - Yes 
        char CommandDataLength; // Number of bytes in the command 
        fixed char CommandData[255]; // Array containing the command bytes 
        char ResponseStatus; // Response Status (PORT_STATUS enum) 
        char ResponseDataLength; // how many bytes in the response 
        fixed char ResponseData[255]; // an array of response data 
        char IgnoreError; // flag to suppress error box (0 - display,1- suppress) 
        public SSP_COMMAND(Byte comport)
        {
            BaudRate = 9600;
            Timeout = 500;
            PortNumber = (char)comport;
            RetryLevel = '5';
            IgnoreError = '0';
            EncryptionStatus = '0';
            ResponseStatus = '0';
            ResponseDataLength = '0';
            SSPAddress = '0';
            CommandDataLength = '0';
            key = new SSP_FULL_KEY(0123456701234567, 0123456701234567);
        }
    } 
    class Program
    {
        //NOMANGLE int CCONV OpenSSPComPort (SSP_COMMAND * cmd); 
        [DllImport("ITLSSPProc.dll")]
        private static extern int OpenSSPComPort(ref SSP_COMMAND cmd);
        //NOMANGLE int CCONV CloseSSPComPort (void);
        [DllImport("ITLSSPProc.dll")]
        private static extern int CloseSSPComPort();
        static void Main(string[] args)
        {
            SSP_COMMAND cmd = new SSP_COMMAND(3);
            /* IntPtr.BaudRate = 9600; 
            IntPtr.PortName = "COM0"; 
            IntPtr.Parity = Parity.None; 
            IntPtr.StopBits = StopBits.One; 
            */
            Console.WriteLine("open {0}", OpenSSPComPort(ref cmd));
            Console.WriteLine("close {0}", CloseSSPComPort());
            Console.ReadKey();
        }
    }
