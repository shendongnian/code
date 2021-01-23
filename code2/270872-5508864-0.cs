	public class GSInterface
	{
		public string GhostScriptExePath { get; private set; }
		public GSInterface(string gsExePath)
		{
			this.GhostScriptExePath = gsExePath;
		}
		public virtual void CallGhostScript(string[] args)
		{
			var p = new Process();
			p.StartInfo.FileName = this.GhostScriptExePath;
			p.StartInfo.Arguments = string.Join(" ", args);
			p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			p.Start();
			p.WaitForExit();
		}
		public void Print(string filename, string printerName)
		{
			this.CallGhostScript(new string[] {
				"-q",
				"-sDEVICE=mswinpr2",
				"-sPAPERSIZE=a4",
				"-dNOPAUSE",
				"-dNoCancel",
				"-dBATCH",
				"-dDuplex",
				string.Format(@"-sOutputFile=""\\spool\{0}""", printerName),
				string.Format(@"""{0}""", filename)
			});
		}
	}
