    void startmodule()
        {
            ProcessObj = new Process();
            progressBar1.Value = 20;
            ProcessObj.StartInfo.FileName = ApplicationPath;
            progressBar1.Value = 40;
            ProcessObj.StartInfo.Arguments = ApplicationArguments;
            progressBar1.Value = 60;
            ProcessObj.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            progressBar1.Value = 80;
            ProcessObj.Start();
            progressBar1.Value = 100;
        }
