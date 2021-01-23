            var asmPath = AppDomain.CurrentDomain.BaseDirectory; // Your assemblies's root folder
            var asmFullPath1 = System.IO.Path.Combine(asmPath, @"test\ClassLibrary1.dll");
            var asmFullPath2 = System.IO.Path.Combine(asmPath, @"test2\ClassLibrary1.dll");
            Assembly asm1 = System.Reflection.Assembly.LoadFrom(asmFullPath1);
            Assembly asm2 = System.Reflection.Assembly.LoadFrom(asmFullPath2);
            Console.WriteLine(asm1.CodeBase == asm2.CodeBase);
