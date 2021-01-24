            string compiledOutput = "Generated.exe";
            //COMPILATION WORK
            String[] referenceAssemblies = { "System.dll", "System.Drawing.dll", "System.Windows.Forms.dll" };
            CodeDomProvider _CodeCompiler = CodeDomProvider.CreateProvider("CSharp");
            System.CodeDom.Compiler.CompilerParameters _CompilerParameters =
             new System.CodeDom.Compiler.CompilerParameters(referenceAssemblies, "");
            _CompilerParameters.OutputAssembly = compiledOutput;
            _CompilerParameters.GenerateExecutable = true;
            _CompilerParameters.GenerateInMemory = false;
            _CompilerParameters.WarningLevel = 3;
            _CompilerParameters.TreatWarningsAsErrors = true;
            _CompilerParameters.CompilerOptions = "/optimize /target:winexe";//!! HERE IS THE SOLUTION !!
            string _Errors = null;
            try
            {
                // Invoke compilation
                CompilerResults _CompilerResults = null;
                _CompilerResults = _CodeCompiler.CompileAssemblyFromSource(_CompilerParameters, richTextBox1.Text);
                if (_CompilerResults.Errors.Count > 0)
                {
                    // Return compilation errors
                    _Errors = "";
                    foreach (System.CodeDom.Compiler.CompilerError CompErr in _CompilerResults.Errors)
                    {
                        _Errors += "Line number " + CompErr.Line +
                        ", Error Number: " + CompErr.ErrorNumber +
                        ", '" + CompErr.ErrorText + ";\r\n\r\n";
                    }
                }
            }
            catch (Exception _Exception)
            {
                // Error occurred when trying to compile the code
                _Errors = _Exception.Message;
            }
            //AFTER WORK
            if (_Errors == null)
            {
                // lets run the program
                MessageBox.Show(compiledOutput + " Compiled !");
                System.Diagnostics.Process.Start(compiledOutput);
            }
            else
            {
                MessageBox.Show("Error occurred during compilation : \r\n" + _Errors);
            }
