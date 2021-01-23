    using System;
    using System.IO;
    using System.Reflection;
    using System.Security;
    using System.Security.Permissions;
    using System.Collections;
    using System.Security.Policy;
    
    [assembly: AssemblyVersion("1.1.0.0")]
    namespace ShadowLauncher {
    	static class Program {
    		[STAThread]
    		static int Main(string[] args) {
    			if (args.Length == 0 || !File.Exists(args[0]))
    				return 1;
    
    			var assembly = args[0];
    			var realArgs = new string[args.Length - 1];
    			if (realArgs.Length > 0)
    				Array.Copy(args, 1, realArgs, 0, realArgs.Length);
    
    			var permissions = new PermissionSet(PermissionState.Unrestricted);
    
    			AppDomain.CreateDomain(Path.GetFileNameWithoutExtension(assembly),
    				AppDomain.CurrentDomain.Evidence,
    				new AppDomainSetup {
    					ShadowCopyFiles = "true",
    					ConfigurationFile = assembly + ".config",
    					ApplicationBase = Path.GetDirectoryName(Path.GetFullPath(assembly))
    				},
    				permissions
    			).ExecuteAssembly(assembly, AppDomain.CurrentDomain.Evidence, realArgs);
    			return 0;
    		}
    	}
    }
