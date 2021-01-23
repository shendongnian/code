    private FileInfo _source = new FileInfo(@"C:\file.bin");
    private FileInfo _destination = new FileInfo(@"C:\file2.bin");
    
    private void CopyFile()
    {
      if(_destination.Exists)
        _destination.Delete();
      Task.Run(()=>{
        _source.CopyTo(_destination, x=>Dispatcher.Invoke(()=>progressBar1.Value = x));
      }).GetAwaiter().OnCompleted(() => MessageBox.Show("File Copied!"));
    }
