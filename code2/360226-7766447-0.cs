    using System;
    using System.IO;
    using System.Reflection;
    
    class Sample {
        static void Main(){
            var path = @"C:\Code\ESG Server\ExeOutput\bin\debug";
            string[] filePaths = Directory.GetFiles(path, "*.exe");
        
            foreach (var exeReport in filePaths){
                Assembly exe = Assembly.LoadFile(exeReport);
                var exeType = exe.GetTypes()[0];//only one class;
                if(exeType.BaseType.Name != "BaseExe") continue;
                dynamic obj = exe.CreateInstance(exeType.Name);
                Console.WriteLine("Name:{0},Description:{1}", obj.Name, obj.Description);
            }
        }
    }
