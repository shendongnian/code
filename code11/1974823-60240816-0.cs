string output = "";
var proc = new ProcessStartInfo("cmd.exe", "/c arp -a")
{
      CreateNoWindow = true,
      UseShellExecute = false,
      RedirectStandardOutput = true,
      RedirectStandardError = true,
      WorkingDirectory = @"C:\Windows\System32\"
};
Process p = Process.Start(proc);
p.OutputDataReceived += (sender, args1) => { output += args1.Data + Environment.NewLine; };
p.BeginOutputReadLine();
p.WaitForExit();
var dict = new Dictionary<string, string>();
var lines = output.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
foreach(var line in lines)
{
      if(line.Contains("static")|| line.Contains("dynamic"))
      {
         var elements = line.Split(new string[] { "    " }, StringSplitOptions.RemoveEmptyEntries);
         dict.Add(elements[0], elements[1]);
      }
   
   
}
//Enter the IPAddress to retreive the corresponding Mac Address
var macofIpaddress = dict["192.168.137.1"];
Console.WriteLine("Press any key to continue");
Console.Read();
**Output**:
 
