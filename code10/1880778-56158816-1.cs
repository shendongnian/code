    public ISymbolReader GetSymbolReader(ModuleDefinition module, string fileName)
    {
    
       ...
    
       // this just changes the extension
       var pdb_file_name = Mixin.GetPdbFileName(fileName);
    
       // this should be true
       if (File.Exists(pdb_file_name))
       {
          if (Mixin.IsPortablePdb(Mixin.GetPdbFileName(fileName)))
             return new PortablePdbReaderProvider().GetSymbolReader(module, fileName);
    
          try
          {
             return SymbolProvider.GetReaderProvider(SymbolKind.NativePdb).GetSymbolReader(module, fileName);
          }
          catch (Exception)
          {
             // We might not include support for native pdbs.
          }
       }
    
       // cant find the pdb file, your error
       if (throw_if_no_symbol)
          throw new SymbolsNotFoundException(string.Format("No symbol found for file: {0}", fileName));
    
       return null;
    }
