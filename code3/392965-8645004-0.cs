            string myAsmName = "WriteSatelliteAssembly.resources";
            string myAsmFileName = myAsmName + ".dll";
            string resourceName = "WriteSatelliteAssembly.MyResource2.fr.resources";
            string path;
    
            path = AppDomain.CurrentDomain.BaseDirectory + "fr-FR";
            AppDomain appDomain = Thread.GetDomain();
            AssemblyName asmName = new AssemblyName();
            asmName.Name = myAsmName;
            asmName.CodeBase = path;
            asmName.CultureInfo = new CultureInfo("fr");
            AssemblyBuilder myAsmBuilder = appDomain.DefineDynamicAssembly(
                asmName,
                AssemblyBuilderAccess.RunAndSave, path);
            **ModuleBuilder** myModuleBuilder =
                myAsmBuilder.DefineDynamicModule(myAsmFileName,
                myAsmFileName);
            **IResourceWriter** rw =
                myModuleBuilder.DefineResource(resourceName,
                "My Description",ResourceAttributes.Public);
            
            rw.AddResource("resName","My (dynamic) resource value.");
            rw.AddResource("resName2","My (dynamic) second resource value.");
            myAsmBuilder.Save(myAsmFileName);
