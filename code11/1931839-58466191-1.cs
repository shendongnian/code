    System.Diagnostics.Process process = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    string s1 = "--movie_name";
    string s2 = "\"Iron Man\"";
    string s3 = "--top_n";
    string s4 = "10";
    process.StartInfo = new ProcessStartInfo(@"cmd.exe ", @"/c C:\Users\Azizmaiden\Desktop\files\hello\KnnRecommender.py " + s1 + " " + s2 + " " + s3 + " " + s4)
    {
        RedirectStandardOutput = true,
        RedirectStandardInput = true,
        UseShellExecute = false,
        Verb = "runas"
    };
    process.Start();
    string res = "";
    StringBuilder q = new StringBuilder();
    while (!process.HasExited)
    {
        q.Append(process.StandardOutput.ReadToEnd()); 
    }
    string r = q.ToString();
    res = r;
    Console.Write("RESULTS: " + res.ToString());
