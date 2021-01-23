       int fullfilesize = 0;// full size of file
        int DefaultReadValue = 10485760; //read 10 mb at a time
        int toRead = 10485760;
        int position =0;
      //  int 
     //   byte[] ByteReadFirst = new byte[10485760];
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var fs = new FileStream(@"filepath", FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream requestStream = new MemoryStream())
                {
                  
                    fs.Position = position;
                    if (fs.Position >= fullfilesize)
                    {
                        MessageBox.Show(" all done");
                        return;
                    }
                    System.Diagnostics.Debug.WriteLine("file position" + fs.Position);
                    if (fullfilesize-position < toRead)
                    {
                        toRead = fullfilesize - position;
                        MessageBox.Show("last time");
                    }
                    System.Diagnostics.Debug.WriteLine("toread" + toRead);
                    int    bytesRead;
                    byte[] buffer = new byte[toRead];
                    int offset = 0;
                    position += toRead;
                    while (toRead > 0 && (bytesRead = fs.Read(buffer, offset, toRead)) > 0)
                    {
                        toRead -= bytesRead;
                        offset += bytesRead;
                    }
                    toRead = DefaultReadValue;
                    
                }
            }
        }
