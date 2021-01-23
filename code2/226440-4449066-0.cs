    var p = new System.Diagnostics.Process();
    var s = new System.Diagnostics.ProcessStartInfo(uniquePartOfUrl);
    s.UseShellExecute = true;
    s.WindowStyle = ProcessWindowStyle.Normal;
    p.StartInfo = s;
    p.Start();
