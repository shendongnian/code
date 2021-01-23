    <!-- code follows -->
        using System.Diagnostics;
    
        class myapp
        {
            public static void Main()
            {
                Process p1 = new Process();
                p1.StartInfo.FileName = "batch.bat";
                p1.StartInfo.Arguments = "test";
                p1.StartInfo.UseShellExecute = false;
            
                p1.Start();
                p1.WaitForExit();
             }
         }
