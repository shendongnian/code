    public static class PrintTestPageHelper
    {
        [DllImport("printui.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern void PrintUIEntryW(IntPtr hwnd, 
            IntPtr hinst, string lpszCmdLine, int nCmdShow);
        /// <summary>
        /// Print a Windows test page.
        /// </summary>
        /// <param name="printerName">
        /// Format: \\Server\printer name, for example:
        /// \\myserver\sap3
        /// </param>
        public static void Print(string printerName)
        {
            var printParams = string.Format(@"/k /n{0}", printerName);
            PrintUIEntryW(IntPtr.Zero, IntPtr.Zero, printParams, 0);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            PrintTestPageHelper.Print(@"\\printserver.code4life.com\sap3");
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
