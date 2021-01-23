    using System;
    using System.Runtime.InteropServices;
    
    //C:\Program Files (x86)\Microsoft Visual Studio 11.0\Visual Studio Tools for
    //Office\PIA\Office14\Microsoft.Office.Interop.Excel.dll
    using Excel = Microsoft.Office.Interop.Excel; 
    class Program
	{
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();
		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		const int SW_HIDE = 0;
		const int SW_SHOW = 5;
		static void Main(string[] args)
		{
			Console.WriteLine("Opening new excel process...");
			var handle = GetConsoleWindow();
			ShowWindow(handle, SW_HIDE);
			try
			{
				Excel.Application Ea = new Excel.Application();
				Ea.Workbooks.Add();
				Ea.Visible = false;
			}
			catch (Exception exep)
			{
				Console.WriteLine(exep.Message);
				Console.ReadKey();
			}
		}
	}
