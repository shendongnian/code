    using Excel = Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    class Sample
	{
		[DllImport("user32.dll")]
		static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);
		Process GetExcelProcess(Excel.Application excelApp)
		{
			int id;
			GetWindowThreadProcessId(excelApp.Hwnd, out id);
			return Process.GetProcessById(id);
		}
	}
