    class Program
    {
        [DllImport("oleaut32.dll")]
        static extern uint SysStringByteLen(IntPtr bstr);
    
        static void Main()
        {
            string str = "wordcounter";
            var bstr = Marshal.StringToBSTR(str);
            // divide by 2 because the SysStringByteLen function returns 
            // number of bytes and each character takes 2 bytes (UTF-16)
            var numberOfLetters = SysStringByteLen(bstr) / 2; 
            Console.WriteLine(numberOfLetters);
        }
    }
