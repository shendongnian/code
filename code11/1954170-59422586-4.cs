    using System.Diagnostics;
    using System.Threading;
    
    
    namespace PyTest
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                string workingDirectory = @"C:\Test";
                string imageFileName = "ocr.JPG";
    
                var process = new Process
                {                
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        RedirectStandardInput = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = false,
                        WorkingDirectory = workingDirectory
                    }
                
                };
                process.Start();
                
    
                using (var sw = process.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        // Vital to activate Anaconda
                        sw.WriteLine(@"C:\Users\xxxxxxx\Anaconda3\Scripts\activate.bat");
                        Thread.Sleep(500);
                        // Activate your environment
                        sw.WriteLine("conda activate py3.7.4");
                        Thread.Sleep(500);
                        sw.WriteLine($"python ocr_test.py --path {imageFileName}");
                        Thread.Sleep(50000);
                    }                  
                    
                }           
            }
        }   
        }
