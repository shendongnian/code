using (StreamWriter sw = new StreamWriter("myFunctions.cmd"))
{
    for (int j = 0; j < 25; j++)
    {
        for (int i = 0; i < Device_Numbers.Count; i++)
        {
            sw.WriteLine("myFunction.exe " + i + " = " + j);
        }
    }
}
using (Process process = new Process())
{
    process.StartInfo.FileName = "cmd.exe";
    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    process.StartInfo.Arguments = "/C myFunctions.cmd";
    process.Start();
    process.WaitForExit();
}
