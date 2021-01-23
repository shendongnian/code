        using System.Diagnostics;
        private void button1_Click(object sender, EventArgs e) 
          {
            string filename= "calc.exe";
            Process runcalc= Process.Start(filename);
            while (runcalc.MainWindowHandle == IntPtr.Zero)
            {
                System.Threading.Thread.Sleep(10);
                runcalc.Refresh();
            }
        }
