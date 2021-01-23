             protected override System.CodeDom.Compiler.CompilerResults FromFileBatch(System.CodeDom.Compiler.CompilerParameters options, string[] fileNames)
            {
    
    #if NETSTANDARD2_0
                return NetStandardFromFileBatch(options, fileNames);
    #else
                return OldFromFileBatch(options, fileNames);
    #endif
            }
    
    
    
    
    #if NETSTANDARD2_0         
    
    
    
            protected System.CodeDom.Compiler.CompilerResults NetStandardFromFileBatch(System.CodeDom.Compiler.CompilerParameters options, string[] fileNames)
            {
                //// C:\Program Files\dotnet\sdk\2.0.0\Roslyn
    
                //string sysver = System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion();
                //System.Console.WriteLine(sysver);
    
    
                //string pf64 = System.Environment.ExpandEnvironmentVariables("%ProgramW6432%");
                //string pf32 = System.Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%");
                //string pf = pf32;
    
                //if (System.IntPtr.Size * 8 == 64)
                //    pf = pf64;
    
                //// compilerDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles);
                ////compilerDirectory = System.IO.Path.Combine(compilerDirectory, "dotnet", "sdk", "2.0.0", "Roslyn");
                //compilerDirectory = System.IO.Path.Combine(pf32, "MSBuild", "14.0", "Bin");
                //if (System.IntPtr.Size * 8 == 64)
                //    compilerDirectory = System.IO.Path.Combine(compilerDirectory, "amd64");
    
                string assemblyName = System.IO.Path.GetFileNameWithoutExtension(options.OutputAssembly);
    
                Microsoft.CodeAnalysis.SyntaxTree[] syntaxTrees = new Microsoft.CodeAnalysis.SyntaxTree[fileNames.Length];
    
                for (int i = 0; i < fileNames.Length; ++i)
                {
                    string fileContent = System.IO.File.ReadAllText(fileNames[i], System.Text.Encoding.UTF8);
    
                    Microsoft.CodeAnalysis.VisualBasic.VisualBasicParseOptions op = null;
    
                    // ERR_EncodinglessSyntaxTree = 37236 - Encoding must be specified... 
                    syntaxTrees[i] = Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxTree.ParseText(
                        fileContent, op, fileNames[i], System.Text.Encoding.UTF8
                    );
    
                }
    
                Microsoft.CodeAnalysis.MetadataReference[] references =
                    new Microsoft.CodeAnalysis.MetadataReference[options.ReferencedAssemblies.Count];
    
                for (int i = 0; i < references.Length; ++i)
                {
                    references[i] = Microsoft.CodeAnalysis.MetadataReference.CreateFromFile(
                        options.ReferencedAssemblies[i]
                    );
                }
    
    
    
                Microsoft.CodeAnalysis.VisualBasic.VisualBasicCompilationOptions co =
                    new Microsoft.CodeAnalysis.VisualBasic.VisualBasicCompilationOptions
                (
                    Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary
                );
    
                co.WithOptionStrict(Microsoft.CodeAnalysis.VisualBasic.OptionStrict.Off);
                co.WithOptionExplicit(false);
                co.WithOptionInfer(true);
    
                Microsoft.CodeAnalysis.Compilation compilation = Microsoft.CodeAnalysis.VisualBasic.VisualBasicCompilation.Create(
                    assemblyName,
                    syntaxTrees,
                    references,
                    co
                );
    
    
                System.CodeDom.Compiler.CompilerResults compilerResults = new System.CodeDom.Compiler.CompilerResults(options.TempFiles);
    
                compilerResults.NativeCompilerReturnValue = -1;
    
                // using (var dllStream = new System.IO.MemoryStream())
                using (System.IO.FileStream dllStream = System.IO.File.Create(options.OutputAssembly))
                {
                    using (System.IO.MemoryStream pdbStream = new System.IO.MemoryStream())
                    {
                        Microsoft.CodeAnalysis.Emit.EmitResult emitResult = compilation.Emit(dllStream, pdbStream);
                        if (!emitResult.Success)
                        {
    
                            foreach (Microsoft.CodeAnalysis.Diagnostic diagnostic in emitResult.Diagnostics)
                            {
                                // options.TreatWarningsAsErrors
                                if (diagnostic.IsWarningAsError || diagnostic.Severity == Microsoft.CodeAnalysis.DiagnosticSeverity.Error)
                                {
                                    string errorNumber = diagnostic.Id;
                                    string errorMessage = diagnostic.GetMessage();
    
                                    string message = $"{errorNumber}: {errorMessage};";
                                    string fileName = diagnostic.Location.SourceTree.FilePath;
    
                                    Microsoft.CodeAnalysis.FileLinePositionSpan lineSpan = diagnostic.Location.GetLineSpan();
                                    string codeInQuestion = lineSpan.Path;
                                    int line = lineSpan.StartLinePosition.Line;
                                    int col = lineSpan.StartLinePosition.Character;
    
                                    compilerResults.Errors.Add(
                                        new System.CodeDom.Compiler.CompilerError(fileName, line, col, errorNumber, errorMessage)
                                    );
                                } // End if 
    
                            } // Next diagnostic 
    
                            // emitResult.Diagnostics
                            // CheckCompilationResult(emitResult);
                        }
                        else
                        {
                            compilerResults.PathToAssembly = options.OutputAssembly;
                            compilerResults.NativeCompilerReturnValue = 0;
                        }
                    }
                }
    
                // compilerResults.CompiledAssembly = System.Reflection.Assembly.Load(array3, null);
    
                return compilerResults;
            }
    #endif
