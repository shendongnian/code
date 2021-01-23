    public void ConvertWavToMp3 (TempFile srcFile, string title, Action<TempFile, Exception> complete)
    {
        var argument_fmt = "-S --resample 16 --tt {0} --add-id3v2  {1} {2}";
        var dstFile = new TempFile(Path.GetTempFileName());
        var proc = new System.Diagnostics.Process ();
        proc.EnableRaisingEvents = true;
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.FileName = "lame";
        proc.StartInfo.Arguments = String.Format (argument_fmt, 
                                                  title,
                                                  srcFile.Path,
                                                  dstFile.Path);
        using(var wh = new System.Threading.ManualResetEvent(false))
        {
            proc.Exited += delegate(object sender, EventArgs e) {
                proc.WaitForExit();
                srcFile.Delete();
                complete(dstFile, null);
                wh.Set();
            };
            
            proc.Start();
            wh.WaitOne();
        }
    }
