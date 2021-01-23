    string decryptedWebResourceIdentifier = DecryptWebResourceIdentifier(encryptedWebResourceIdentifier);
    string assemblyName = null;
    string resourceName = decryptedWebResourceIdentifier.Split("|")[1];
    string resourceContent;
    //Switch between assembly complete name and partial name
    if (decryptedWebResourceIdentifier.Split("|")[0].Contains(",")) {
	  assemblyName = string.Format("{0}, Version={1}, Culture={2}, PublicKeyToken={3}",   decryptedWebResourceIdentifier.Substring(1).Split("|")[0].Split(",")).Replace("Culture=,", "Culture=neutral,");
    } else {
	  assemblyName = decryptedWebResourceIdentifier.Split("|")[0].Substring(1);
    }
    //Gets resource assembly
    Assembly resourceAssembly;
    //If a assembly partial name is defined, get it's assembly reference or else, get current assembly
    if (!string.IsNullOrEmpty(assemblyName)) {
	  resourceAssembly = Assembly.Load(assemblyName);
    } else {
	  resourceAssembly = this.GetType().Assembly;
    }
    //Get resource stream and his content
    resourceContent = new StreamReader(resourceAssembly.GetManifestResourceStream(resourceName)).ReadToEnd();
