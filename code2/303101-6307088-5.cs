    System.Diagnostics.ProcessStartInfo process= new
        System.Diagnostics.ProcessStartInfo(@"MyApplication.exe");
    process.WindowStyle=System.Diagnostics.ProcessWindowStyle.Minimized;
    process.UseShellExecute=false; // Optional
    System.Diagnostics.Process.Start(process);
