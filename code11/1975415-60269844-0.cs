        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            // this is an example file
            string filePath = @"C:\file.gif";
            // it determines how many bytes of data will be received from the stream each time.
            byte[] buffer = new byte[4096];
            int byteCount = 0;
            // we are preparing to read stream.
            using (FileStream fs = new FileStream(filePath, FileMode.Open, System.IO.FileAccess.Read))
            using (MemoryStream ms = new MemoryStream())
            {
                // read the stream bytes and fill buffer
                while ((byteCount = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // if the task was canceled
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    // write buffer to memory stream
                    ms.Write(buffer, 0, byteCount);
                }
            }
        }
