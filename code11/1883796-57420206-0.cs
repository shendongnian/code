    using System;
    using Wyam.Common.IO;
    using Wyam.Core.Execution;
    using Wyam.Docs;
    
    namespace ConsoleApp3
    {
        class Program
        {
            static void Main(string[] args)
            {
                Wyam.Common.Tracing.Trace.AddListener(new System.Diagnostics.TextWriterTraceListener(Console.Out));
                var engine = new Engine();
                engine.Namespaces.Add("Wyam.Docs"); // or razor will complain
                engine.FileSystem.InputPaths.Add(new DirectoryPath(@"C:\temp\wyam.test\content"));
                engine.FileSystem.InputPaths.Add(new DirectoryPath(@"C:\temp\wyam.test\input"));
                engine.FileSystem.OutputPath = new DirectoryPath(@"C:\temp\wyam.test\site");
                var dr = new Docs();
                dr.Apply(engine);
                engine.Execute();
            }
        }
    }
