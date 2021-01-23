            // Create assamblly in Memory
			CodeSnippetCompileUnit code = new CodeSnippetCompileUnit(classCode);
			CSharpCodeProvider provider = new CSharpCodeProvider();
			CompilerResults results = provider.CompileAssemblyFromDom(compileParams, code);
            foreach(var type in results.CompiledAssembly)
            {
                  // Your analysis go here
            }
