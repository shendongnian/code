    private void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            {
                //MessageBox.Show(e.Result.Text);
                try
                {
                    _serialPort = new SerialPort();
                    _serialPort.PortName = "COM3";
                    _serialPort.Open();
                    _serialPort.Write("#27 P1600 S750\r");
                    Console.WriteLine("#27 P1500 S750\r");
                    string output;
                    output = "";
                    //Example: "Q <cr>" 
                    //This will return a "." if the previous move is complete, or a "+" if it is still in progress. 
                    while (!(output == ".")) //loop until you get back a period 
                    {
                        _serialPort.Write("Q  \r");
                        output = _serialPort.ReadExisting();
                        Console.WriteLine(output);
                        Thread.Sleep(10);
                    }
                    _serialPort.Close();
                }
                catch (TimeoutException) { }
    
            }
