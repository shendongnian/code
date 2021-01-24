csharp
using System;
using System.Windows.Forms;
namespace YourApp
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Form form = null;
			if(Array.IndexOf(args, "--form2") > -1) form = new Form2();
			else if(Array.IndexOf(args, "--form3") > -1) form = new Form3();
			else if(Array.IndexOf(args, "--form4") > -1) form = new Form4();
			else form = new Form1();
			Application.Run(form);
		}
	}
}
should work, and then just launch your executable with one of those parameters.
