    using System;
    using System.IO;
    
    namespace SimplePrinting
    {
    	/// <summary>
    	/// Summary description for Class1.
    	/// </summary>
    	class SimplePrinting
    	{
    		/// <summary>
    		/// The main entry point for the application.
    		/// </summary>
    		[STAThread]
    		static void Main(string[] args)
    		{
    			string printingTaskFileName = Path.GetTempFileName(); // file in %temp%
    
    			System.IO.FileStream printingTaskFile;
    			System.IO.StreamWriter printingTaskStream;
    
    			printingTaskFile = new System.IO.FileStream(printingTaskFileName, FileMode.Append);
    			printingTaskStream = new System.IO.StreamWriter(printingTaskFile, System.Text.Encoding.Default);
    
    			printingTaskStream.Write("some content here");
    			printingTaskStream.Flush();
    			printingTaskStream.Close();
    
    			File.Copy(printingTaskFileName, @"\\127.0.0.1\TEST", true); // also can be \\127.0.0.1\PNT5 or smth like that
    			File.Delete(printingTaskFileName);
    		}
    	}
    }
