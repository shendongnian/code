    using System;
    using System.IO;
    using System.Text;
    
    class ConvertUTF16toUTF8 {
        static int Main(string[] argv){
            if(argv.Length != 2){
                Console.WriteLine("conv InputFilePath OutputFilePath");
                return -1;
            }
            File.WriteAllText(argv[1], File.ReadAllText(argv[0], Encoding.Unicode), Encoding.UTF8);
            return 0;
        }
    }
