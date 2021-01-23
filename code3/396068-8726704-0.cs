    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    
    namespace FlaechenupdateScript
    {
    
    
        static class Program
        {
    
    
            // http://www.codeproject.com/KB/cs/runtimecompiling.aspx
            private static System.Reflection.Assembly BuildAssembly(string code)
            {
                Microsoft.CSharp.CSharpCodeProvider provider =
                   new Microsoft.CSharp.CSharpCodeProvider();
                System.CodeDom.Compiler.ICodeCompiler compiler = provider.CreateCompiler();
                System.CodeDom.Compiler.CompilerParameters compilerparams = new System.CodeDom.Compiler.CompilerParameters();
    
                string strLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string strBasePath = System.IO.Path.GetDirectoryName(strLocation);
    
                string strSerializationTypes = System.IO.Path.Combine(strBasePath, "SerializationTypes.dll");
                string strFileHelpersLocation = System.IO.Path.Combine(strBasePath, "FileHelpers.dll");
    
                compilerparams.ReferencedAssemblies.Add(strSerializationTypes);
                compilerparams.ReferencedAssemblies.Add(strFileHelpersLocation);
    
                compilerparams.GenerateExecutable = false;
                compilerparams.GenerateInMemory = true;
                System.CodeDom.Compiler.CompilerResults results =
                   compiler.CompileAssemblyFromSource(compilerparams, code);
                if (results.Errors.HasErrors)
                {
                    System.Text.StringBuilder errors = new System.Text.StringBuilder("Compiler Errors :\r\n");
                    foreach (System.CodeDom.Compiler.CompilerError error in results.Errors)
                    {
                        errors.AppendFormat("Line {0},{1}\t: {2}\n",
                               error.Line, error.Column, error.ErrorText);
                    }
                    throw new Exception(errors.ToString());
                }
                else
                {
                    return results.CompiledAssembly;
                }
            } // End Function BuildAssembly
    
    
            public static Type GetClassType(Type tt, string strDelimiter)
            {
                string strFullTypeName = tt.FullName;
                string strTypeUniqueName = System.Guid.NewGuid().ToString() + System.Guid.NewGuid().ToString() + System.Guid.NewGuid().ToString() + System.Guid.NewGuid().ToString();
                strTypeUniqueName = "_" + strTypeUniqueName.Replace("-", "_");
    
                string xx = @"
                namespace CrapLord
                {
        
                    [FileHelpers.DelimitedRecord(""" + strDelimiter + @""")]
                    public class " + strTypeUniqueName + @" : " + strFullTypeName + @"
                    {
    
                    }
    
                }
    
                ";
    
                System.Reflection.Assembly a = BuildAssembly(xx);
    
                var o = a.CreateInstance("CrapLord." + strTypeUniqueName);
                Type t = o.GetType();
    
                //System.Reflection.MethodInfo mi = t.GetMethod("EvalCode");
                //var s = mi.Invoke(o, null);
                
                return t;
            }
    
    
            /// <summary>
            /// Der Haupteinstiegspunkt für die Anwendung.
            /// </summary>
            [STAThread]
            static void Main()
            {
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Form1());
    
                Type t = GetClassType(typeof(Tools.Serialization.CSV.Customer), ",");
    
                //FileHelpers.FileHelperEngine engine = new FileHelpers.FileHelperEngine(typeof(SemicolonCustomer));
                FileHelpers.FileHelperEngine engine = new FileHelpers.FileHelperEngine(t);
    
                // To read use:
                string str = @"D:\Stefan.Steiger\Documents\Visual Studio 2010\Projects\MvcExamples\FileHelpers_Examples_CSharp_VbNet\Data\SemicolonCustomers.txt";
                str = @"D:\Stefan.Steiger\Documents\Visual Studio 2010\Projects\MvcExamples\FileHelpers_Examples_CSharp_VbNet\Data\CustomersDelimited.txt";
                
                //str = @"D:\Stefan.Steiger\Desktop\FileHelpers_Examples_CSharp_VbNet\Data\CustomersDelimited.txt";
                Tools.Serialization.CSV.Customer[] custs = (Tools.Serialization.CSV.Customer[])engine.ReadFile(str);
                //Customer[] custs = (Customer[]) engine.ReadFile("yourfile.txt");
    
    
                foreach (Tools.Serialization.CSV.Customer cli in custs)
                {
                    Console.WriteLine();
                    Console.WriteLine("Customer: " + cli.CustId.ToString() + " - " + cli.Name);
                    Console.WriteLine("Added Date: " + cli.AddedDate.ToString("d-M-yyyy"));
                    Console.WriteLine("Balance: " + cli.Balance.ToString());
                    Console.WriteLine();
                    Console.WriteLine("-----------------------------");
                } // Next cli
    
    
    
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(" --- Press any key to continue --- ");
                Console.ReadKey();
            }
    
    
        }
    
    
    }
