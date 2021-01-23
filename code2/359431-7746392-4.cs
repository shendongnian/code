       public ICommand OpenFileCommand { get; set; }
       
       public MainViewModel()
       {
           OpenFileCommand = new RelayCommand(OpenDialog) { IsEnabled = true };
          
       }
       private void OpenDialog()
       {
           OpenFileDialog ofd = new OpenFileDialog();
           if ((bool)ofd.ShowDialog())
           {
               _fileName = ofd.File.Name;
               FileStream fs = ofd.File.OpenRead();
               fileSize = (double)fs.Length;
               //txtFileName.Text = fileName;// Apply Binding 
               index = 0;
               sendData = 0;
               byte[] file = new byte[fs.Length];
               fs.Read(file, 0, file.Length);
               //convertToChunks(file);
               prgUpload.Maximum = fileChunks.Count;
               prgUpload.Value = 0;
               //uploadChunks(index);
           }
       }
