    class Program
    {
        static void Main ( string [ ] args )
        {
            string[] password = { "74f3d3a287cee548c1842c07090d6a274dd0ddbd04bfd1e4694861a369bc7304" };
            string[] serial = { "184393900006" };
            byte[] rma_pin = new byte[32];
            
            int rc = GetRmaPin(password, serial, rma_pin);
            
            Console.WriteLine ( "Result: " + rc.ToString ( ) );
            Console.WriteLine ( "Payload: " + BitConverter.ToString ( rma_pin ).Replace ( "-" , "" ) );
            Console.Read ( );
        }
        [DllImport ( "SecurityProduction.dll" , EntryPoint = "GetRmaPin" , CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRmaPin (
            [In][MarshalAs ( UnmanagedType.LPArray , ArraySubType = UnmanagedType.LPStr )] string [ ] password ,
            [In][MarshalAs ( UnmanagedType.LPArray , ArraySubType = UnmanagedType.LPStr )] string [ ] serial ,
            byte[] rmap_in );
    }
