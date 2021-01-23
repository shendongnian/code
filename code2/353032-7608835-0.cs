    using System;
    using System.IO;
    using Mono.Cecil;
    using Mono.Cecil.Cil;
    using Mono.Cecil.Pdb;
    
    namespace TestPdb
    {
        class Program
        {
            static void Main(string[] args)
            {
                // we use a Stream for the assembly
                AssemblyDefinition asm;
                using (FileStream asmStream = new FileStream("testpdb.exe", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    asm = AssemblyDefinition.ReadAssembly(asmStream);
                }
    
                // we use a Stream for the PDB
                using (FileStream symbolStream = new FileStream("testpdb.pdb", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    asm.MainModule.ReadSymbols(new PdbReaderProvider().GetSymbolReader(asm.MainModule, symbolStream));
                }
    
                TypeDefinition type = asm.MainModule.GetType("TestPdb.Program");
    
                foreach (MethodDefinition method in type.Methods)
                {
                    Console.WriteLine("Method:" + method.Name);
                    foreach (Instruction ins in method.Body.Instructions)
                    {
                        Console.WriteLine(" " + ins);
                        if (ins.SequencePoint != null)
                        {
                            Console.WriteLine("  Url:" + ins.SequencePoint.Document.Url);
                            // see http://blogs.msdn.com/b/jmstall/archive/2005/06/19/feefee-sequencepoints.aspx
                            if (ins.SequencePoint.StartLine != 0xFEEFEE)
                            {
                                Console.WriteLine("  StartLine:" + ins.SequencePoint.StartLine + " StartColumn:" + ins.SequencePoint.StartColumn);
                                Console.WriteLine("  EndLine:" + ins.SequencePoint.EndLine + " EndColumn:" + ins.SequencePoint.EndColumn);
                            }
                            // etc...
                        }
                    }
                }   
            }
        }
    }
