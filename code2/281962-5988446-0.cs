    System.Diagnostics.Process proc = new System.Diagnostics.Process();      
    const string filename = @"/*some file location*/";
    proc.StartInfo.FileName = filename;
    proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;    
    proc.StartInfo.CreateNoWindow = true;        
    proc.Start();          
    proc.WaitForExit();
