            using System.Diagnostics;
            static void Main()
            {
               Process batch;
               batch = Process.Start("ping.exe", "localhost");
               batch.WaitForExit();
               batch.Close();
               batch = Process.Start("choice.exe", "");
               batch.WaitForExit();
               batch.Close();
               batch = Process.Start("ping.exe", "localhost -n 10");
               batch.WaitForExit();
               batch.Close();
          }
