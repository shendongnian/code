    using System;
	using System.Collections.Generic;
	using System.Reflection;
	using System.IO;
	namespace WindowsForm
	{
		public partial class Form1 : Form
		{
			Dictionary<string, Assembly> _libs = new Dictionary<string, Assembly>();            
					
			public Form1()
			{
				InitializeComponent();
				AppDomain.CurrentDomain.AssemblyResolve += FindDLL;
			}
			private Assembly FindDLL(object sender, ResolveEventArgs args)
			{
				string keyName = new AssemblyName(args.Name).Name;
				// If DLL is loaded then don't load it again just return
				if (_libs.ContainsKey(keyName)) return _libs[keyName];
				
				
				using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("YourNamespaceGoesHere." + keyName + ".dll"))  // <-- To find out the Namespace name go to Your Project >> Properties >> Application >> Default namespace
				{
					byte[] buffer = new BinaryReader(stream).ReadBytes((int)stream.Length);
					Assembly assembly = Assembly.Load(buffer);
					_libs[keyName] = assembly;
					return assembly;
				}
			}
			
			//
			// Your Methods here
			//
			
		}
	}
