        var psi = new System.Diagnostics.ProcessStartInfo();
        psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        psi.FileName = browser.Document.Url.ToString();
        var proc = System.Diagnostics.Process.Start(psi);
        //after a while...
        proc.Kill();
