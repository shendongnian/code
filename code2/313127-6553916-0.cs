    Process process = Process.Start(new ProcessStartInfo("cmd.exe", "/K more") {
      UseShellExecute = false,
      RedirectStandardInput = true,
      RedirectStandardError = true,
      RedirectStandardOutput = false
    });
    
    private void button1_Click(object sender, EventArgs e) {
      Log("Button has been pressed");
      MessageBox.Show(process.StandardError.ReadToEnd());
    }
    
    private void Log(string message) {
      process.StandardInput.WriteLine(message);
    }
