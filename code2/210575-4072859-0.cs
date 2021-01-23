    using System;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(Vb6Format("hi there", ">"));
            Console.WriteLine(Vb6Format("hI tHeRe", "<"));
            Console.WriteLine(Vb6Format("hi there", ">!@@@... not @@@@@"));
            Console.ReadLine();
        }
    
        public static string Vb6Format(object expr, string format) {
            string result;
            int hr = VarFormat(ref expr, format, 0, 0, 0, out result);
            if (hr != 0) throw new COMException("Format error", hr);
            return result;
        }
        [DllImport("oleaut32.dll", CharSet = CharSet.Unicode)]
        private static extern int VarFormat(ref object expr, string format, int firstDay, int firstWeek, int flags,
            [MarshalAs(UnmanagedType.BStr)] out string result);
    }
