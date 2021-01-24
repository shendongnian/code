    using System;
    using System.Diagnostics;
    using System.IO;
    namespace Logic
    {
    public class RunScript
    {
        string _parameterString = string.Format("{0} {1} {2} {3}","main.py", "Testuser", "TestPw", "MyEnviroment");
        string _resultCon;
        public string Start()
        {
            ProcessStartInfo _pySkript = new ProcessStartInfo();
            _pySkript.WorkingDirectory = @"D:\GitRepos\ScriptRunner\PyScript\";
            _pySkript.FileName = "python";
            _pySkript.Arguments = _parameterString;
            _pySkript.UseShellExecute = false;
            _pySkript.RedirectStandardOutput = true;
            _pySkript.CreateNoWindow = true;
            _pySkript.RedirectStandardError = true;
            _pySkript.RedirectStandardInput = true;
            _pySkript.ErrorDialog = false;
            _pySkript.WindowStyle = ProcessWindowStyle.Hidden;
            try
            {
                using (Process process = Process.Start(_pySkript))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        _resultCon = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                _resultCon = ex.ToString();
            }
            return _resultCon;
        }
      }
    }
