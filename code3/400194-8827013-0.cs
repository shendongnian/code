    class MyTestProcess
    {
        static void Main()
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false ;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            
            p.StartInfo.FileName = @"path\bin\Debug\print_out_test.exe";
            p.StartInfo.CreateNoWindow = true;
            p.Start();
           
            System.IO.StreamWriter wr = p.StandardInput;
            System.IO.StreamReader rr = p.StandardOutput;
    
            wr.Write("BlaBlaBla" + "\n");
            Console.WriteLine(rr.ReadToEnd());
            wr.Flush();
        }
    }
