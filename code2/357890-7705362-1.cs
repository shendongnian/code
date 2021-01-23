    private void sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
                {
                    try
                    {
                        while (sp.BytesToRead > 1)
                        {
                            string line = sp.ReadLine().Trim();
        
                            if (line == "EOC")
                            {
                                //finish
                                this.progressBar1.Visible = false;
                            }
                            else
                            {
                                //string data = sp.ReadExisting();
                                _serialBuffer.Enqueue(line);
                                if (this.progressBar1.Value < 100)
                                    this.progressBar1.Value++;
                                else
                                    this.progressBar1.Value = 0;
                            }
                  }
        
         }
