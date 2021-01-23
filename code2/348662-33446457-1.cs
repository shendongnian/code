    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Diagnostics;
    using System.Management.Automation;
    namespace System.Diagnostics {
    	public class Shell : System.Dynamic.DynamicObject {
    		public Shell(): base() { }
    		public Shell(bool window) { Window = window; }
    		static string[] ScriptExtensions = new string[] { ".exe", ".cmd", ".bat", ".ps1", ".csx", ".vbs" };
    		public string Path { get { return Environment.GetEnvironmentVariable("PATH"); } set { Environment.SetEnvironmentVariable("PATH", value); } }
    		PowerShell pshell = null;
    		public PowerShell Instance { get { return pshell ?? pshell = PowerShell.Create(); } }
    		public bool Window { get; set; }
    		public ICollection<PSObject> Ps(string cmd) {
    			Instance.AddScript(cmd);
    			return Instance.Invoke();
    		}
    		public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) {
    			var exe = Path.Split(';').SelectMany(p => ScriptExtensions.Select(ext => binder.Name + ext)).FirstOrDefault(p => File.Exists(p));
    			if (exe == null) exe = binder.Name + ".exe";
    			var info = new ProcessStartInfo(exe);
    			var sb = new StringBuilder();
    			foreach (var arg in args) {
    				var t = arg.ToString();
    				if (sb.Length > 0) sb.Append(' ');
    				if (t.Contains(' ')) { sb.Append('"'); sb.Append(t); sb.Append('"'); } else sb.Append(t);
    			}
    			info.Arguments = sb.ToString();
    			info.CreateNoWindow = !Window;
    			info.UseShellExecute = false;
    			info.WindowStyle = Window ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden;
    			try {
    				var p = Process.Start(info);
    				p.WaitForExit();
    				result = p.ExitCode;
    				return true;
    			} catch {
    				result = null;
    				return false;
    			}
    		}
    	}
    }
