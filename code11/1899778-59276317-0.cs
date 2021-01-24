    static void Main(string[] args)
    {
    var psi = new ProcessStartInfo();
    psi.FileName = @"C:\Users\kemal\Anaconda3\envs\movingDriving\python.exe";
    var script = @"C:\Users\kemal\Desktop\testSendData.py";
    var arg1 = "kkk";
    psi.Arguments = $" \"{script}\" \"{arg1}\"";
    psi.UseShellExecute = false;
    psi.CreateNoWindow = true;
    psi.RedirectStandardOutput = true;
    psi.RedirectStandardError = true;
    var errors = "";
    var results = "";
    using (var process = Process.Start(psi))
    {
    errors = process.StandardError.ReadToEnd();
    results = process.StandardOutput.ReadToEnd();
    StreamReader reader = process.StandardOutput;
    Console.WriteLine(psi.Arguments.ToString());`enter code here`
    }
    Console.WriteLine("Errors: " + errors);
    Console.WriteLine("Result: " + results);
    }
