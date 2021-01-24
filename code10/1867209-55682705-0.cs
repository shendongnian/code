            using Access = Microsoft.Office.Interop.Access;
            private void button1_Click(object sender, EventArgs e)
        {
            
           Access.Application oAccess = new Access.Application();
           oAccess.OpenCurrentDatabase(@"C:\test\test.adp", false);
           var Version = oAccess.Run("GetMyVersion");//Name of procedure in Access module
           MessageBox.Show(Version.ToString());
           oAccess.CloseCurrentDatabase();
            
            foreach (Process Proc in Process.GetProcesses())
            if (Proc.ProcessName.Equals("MSACCESS"))  
            Proc.Kill();
        }
