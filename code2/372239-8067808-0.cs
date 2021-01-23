    using System;
    using System.IO;
    using Microsoft.Build.Utilities;
    using Microsoft.Build.Framework;
    
    namespace Foo.Build.Tasks {
    
        public sealed class GenerateVersion : Task {
    
            [Output]
            public ITaskItem[] GeneratedFiles { get; private set; }
    
            public override bool Execute() {
                string objPath = Path.Combine(Path.GetDirectoryName(this.BuildEngine3.ProjectFileOfTaskNode), "obj");
                string path = Path.Combine(objPath, "VersionInfo.cs");
    
                File.WriteAllText(path, @"using System.Reflection;
    [assembly: AssemblyVersion(""2.0.0"")]");
    
                GeneratedFiles = new[] { new TaskItem(path) };
    
                return true;
            }
    
        }
    
    }
