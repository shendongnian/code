        /// <summary>
        /// <para>This function performs the compile operation and return the compiled assembly.</para>
        /// </summary>
        /// <param name="source">The source code of the script to compile.</param>
        /// <param name="libs">A collection of additional libraries to compile the script.</param>
        /// <returns>The compiled assembly.</returns>
        internal Assembly Compile(string source, List<string> libs)
        {
            var libraries = new List<string>(libs);
            CodeDomProvider codeProvider = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } });
            var compilerParams = new CompilerParameters
                                     {
                                         CompilerOptions = "/target:library /optimize",
                                         GenerateExecutable = false,
                                         GenerateInMemory = true,
                                         IncludeDebugInformation = true,
                                         TreatWarningsAsErrors = false
                                     };
            string assemblyDllPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            // Load all the required assemblies depending on the api implementation.
            LoadAssemblies(compilerParams, source, assemblyDllPath, libraries);
            var path = Path.Combine(Path.GetTempPath(), "TF-" + Guid.NewGuid().ToString().ToUpper());
            // replace resx-files from provided libraries with compatible dll's
            var resxs = libraries.FindAll(lb => lb.EndsWith(".resx", StringComparison.OrdinalIgnoreCase));
            var tmpFiles = new List<string>();
            if (resxs.Count > 0)
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                foreach (var resx in resxs)
                {
                    // Get the resources filename
                    var resourceFilename = Path.GetFileNameWithoutExtension(resx);
                    var filename = Path.Combine(path, resourceFilename + ".resources");
                    File.Delete(filename);
                    tmpFiles.Add(filename);
                    // Create a ResXResourceReader for the file items.resx.
                    Stream stream = File.Open(resx, FileMode.Open, FileAccess.Read, FileShare.Read);
                    var rsxr = new ResXResourceReader(stream);
                    // Create a ResXResourceReader for the file items.resources.
                    IResourceWriter writer = new ResourceWriter(filename);
                    // Iterate through the resources and add resources to the resource writer.
                    IDictionary dictionary = new Dictionary<string, string>();
                    foreach (DictionaryEntry d in rsxr)
                    {
                        var k = d.Key.ToString();
                        var v = d.Value.ToString();
                        dictionary.Add(k, v);
                        writer.AddResource(k, v);
                    }
                    // Close the reader.
                    rsxr.Close();
                    stream.Close();
                    writer.Close();
                    compilerParams.EmbeddedResources.Add(filename);
                    string[] errors;
                    var provider = new CSharpCodeProvider(); // c#-code compiler
                    var cu = StronglyTypedResourceBuilder.Create(dictionary, resourceFilename ?? string.Empty, "", provider, false, out errors);
                    var options = new CodeGeneratorOptions
                                      {
                                          BracingStyle = "C",
                                          BlankLinesBetweenMembers = false,
                                          IndentString = "\t"
                                      };
                    var tw = new StringWriter();
                    provider.GenerateCodeFromCompileUnit(cu, tw, options);
                    var libCode = tw.ToString();
                    tw.Close();
                    if (!libraries.Contains(libCode))
                        libraries.Add(libCode);
                }
                libraries.RemoveAll(lb => lb.EndsWith(".resx", StringComparison.OrdinalIgnoreCase));
            }
            
            // actually compile the code
            CompilerResults results = codeProvider.CompileAssemblyFromSource(compilerParams, new List<string>(libraries) { source }.ToArray());
            // remove the temporary files
            foreach (var file in tmpFiles)
                File.Delete(file);
            // remove the resource directory
            if(Directory.Exists(path)) Directory.Delete(path);
            if (results.Errors.HasErrors)
            {
                var sb = new StringBuilder("Compilation error :\n\t");
                foreach (CompilerError error in results.Errors)
                    sb.AppendLine("\t" + error.ErrorText);
                throw new Exception(sb.ToString());
            }
            //get a hold of the actual assembly that was generated
            Assembly generatedAssembly = results.CompiledAssembly;
            // move to some app startup place (this only needs to be set once)
            if (!API.Factory.IsAPIImplementationTypeSet)
            { API.Factory.SetAPIImplementation(Assembly.LoadFile(assemblyDllPath + "\\TenForce.Execution.API.Implementation.dll").GetType("TenForce.Execution.API.Implementation.API")); }
            // Set the implementation type for the API2 as well. This should only be set once.
            if (!Api2.Factory.ImplementationSet)
            { Api2.Factory.SetImplementation(Assembly.LoadFile(assemblyDllPath + "\\TenForce.Execution.Api2.Implementation.dll").GetType("TenForce.Execution.Api2.Implementation.Api")); }
            
            return generatedAssembly;
        }
