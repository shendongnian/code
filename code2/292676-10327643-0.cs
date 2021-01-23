		public static byte[] ReadFully(Stream input)
		{
			var buffer = new byte[16 * 1024];
			using (var ms = new MemoryStream())
			{
				int read;
				while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
				{
					ms.Write(buffer, 0, read);
				}
				return ms.ToArray();
			}
		}
		public App()
		{
			AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
			{
				var assemblyName = new AssemblyName(args.Name);
				if (assemblyName.Name != "Omikad.Core")
					return null;
				var resourceName = "Terem." + assemblyName.Name + ".dll";
				using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
				{
					if (stream == null)
						return null;
					var assemblyData = ReadFully(stream);
					var tmp = Path.Combine(Path.GetTempPath(), "Omikad.Core.dll");
					File.WriteAllBytes(tmp, assemblyData);
					return Assembly.LoadFrom(tmp);
				}
			};
		}
