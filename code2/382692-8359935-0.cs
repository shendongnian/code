    [TestFixture]
    public class InstallTest
    {
        [Test]
        public void InstallAgentNix()
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Tools\plink.exe";
            process.StartInfo.Arguments = @"10.10.9.27 -l root -pw PASSWORD -m C:\test.sh";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
    
            string output = process.StandardOutput.ReadToEnd();
    
            process.WaitForExit();
    
            output = output.Trim().ToLower();
    
            Assert.AreEqual("pass", output, "Agent did not get installed");
        }
    }
