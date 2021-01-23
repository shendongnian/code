     // We need a container for the DLL files that we find and then a container for the instances of 
        // the plug ins created from the dlls. In this test we are only really looking for One such plug in
        // but I prefer to use collections for such things as it allows for a more scalable design. This technique
        // works for 1, 100, or more plugins and/or methods.
        private List<string> _DLLS;
        private List<iAuthenticate> _PlugIns;
        
        private int LoadPlugIns(string Path)
        {
            /// Within the designated Path (and in all subdirectories) locate all .dll files and put the path 
            /// to these files in a collection.
            GetDLLS(Path);
            foreach (string dirName in Directory.GetDirectories(Path))
            {
                LoadPlugIns(dirName);
            }
            
            // For each .dll file, inspect it (using reflection) to determine if it is of the iAuthenticate Type
            // if it is, create and instance of the object and store it in a collection, and assign a delegate to 
            // invoke its Authenticate method from the host application.
            foreach (string DLL in _DLLS)
            
            {
                Assembly myAssembly = Assembly.LoadFrom(DLL);
                Type[] Types = myAssembly.GetTypes();
                foreach (Type myType in Types)
                {
                    Type T = myType.GetInterface("iAuthenticate");
                   if (T != null)
                    {
                        if (_PlugIns == null) { _PlugIns = new List<iAuthenticate>(); }
                        _PlugIns.Add((iAuthenticate)myAssembly.CreateInstance(myType.FullName));
                    }
                }
                foreach (iAuthenticate iAuth in _PlugIns)
                {
                    this.Authorize += iAuth.Authenticate;
                }
            }
            return _PlugIns.Count;
       }
        private void GetDLLS(string Path)
        {
            if (_DLLS == null){_DLLS = new List<string>();}
            foreach (string filename in Directory.GetFiles(Path, "*.dll")) 
            {
                _DLLS.Add(filename);
            }
        }
