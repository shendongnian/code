	void PreloadDLLs()
	{
		Assembly^ assembly = Assembly::GetEntryAssembly();
		array<System::Reflection::AssemblyName^>^ referencedAssemblies = assembly->GetReferencedAssemblies();
		for each(System::Reflection::AssemblyName^ referencedAssemblyName in referencedAssemblies)
		{
			try
			{
				Assembly^ a = assembly->Load(referencedAssemblyName);
			}
			catch(System::Exception^ /*e*/)
			{
			}
		}
	}
