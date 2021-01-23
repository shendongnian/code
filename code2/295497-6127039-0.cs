      internal class MyRegistery : Registry
    {
        /// of course here you can find a way to provide the name (maybe from db)
        private string myassembly = "urAssembly.dll";
        public MyRegistery()
        {
            Scan(
          scanner =>
          {
              scanner.AssembliesFromApplicationBaseDirectory(x => x.ManifestModule.Name== myassembly);
              scanner.AddAllTypesOf<Contracts.IImplementation >();
          });
        }
    }
