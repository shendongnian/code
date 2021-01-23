    System.Diagnostics.Process process=new System.Diagnostics.Process();
    process.StartInfo.FileName = "process.exe";
    process.Start();
    process.WaitForExit();
    //process ended
    MessageBox.Show("Process terminated");
