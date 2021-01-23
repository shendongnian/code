    using System.Diagnostics;
    
    class Program
    {
        static void Main()
        {
    	// A.
    	// Open specified Word file.
    	OpenMicrosoftWord(@"C:\Users\Sam\Documents\Gears.docx");
        }
    
        /// <summary>
        /// Open specified word document.
        /// </summary>
        static void OpenMicrosoftWord(string f)
        {
    	ProcessStartInfo startInfo = new ProcessStartInfo();
    	startInfo.FileName = "WINWORD.EXE";
    	startInfo.Arguments = f;
    	Process.Start(startInfo);
        }
    }
