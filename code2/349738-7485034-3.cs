    class Program
    {
        [DllImport("oleaut32.dll")]
        static extern uint SysStringByteLen(IntPtr bstr);
    
        static void Main()
        {
            string str = "wordcounter";
            var bstr = Marshal.StringToBSTR(str);
            var numberOfLetters = SysStringByteLen(bstr) / 2;
            Console.WriteLine(numberOfLetters);
        }
    }
