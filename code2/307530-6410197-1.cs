        public void MyFunction()
        {
    #if AZURE
            // Code that depends on the Azure assemblies
    #elseif
            // Code that depends on the .NET Framework assemblies
    #end if
        }
