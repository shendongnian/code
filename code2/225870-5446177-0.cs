    ProcessStartInfo info = new ProcessStartInfo();
    info.FileName = "yourProcess";
    info.Arguments = "blah";
    info.StandardOutputEncoding = System.Text.Encoding.GetEncoding("latin1");//important part
    info.RedirectStandardOutput = true;
    info.UseShellExecute = false;
    Process p = Process.Start(info);
    FileStream fs = new FileStream("outputfile.bin", FileMode.Create);
    while((val = p.StandardOutput.Read())!= -1){
        fs.WriteByte((byte)val);
    }
					
    p.WaitForExit();
    fs.Close();
