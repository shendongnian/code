    System.Diagnostics.Process pr = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
    psi.FileName = @"file_path";
    pr.StartInfo = psi;
    pr.Start();
