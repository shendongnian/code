        private void StopReading()
        {
            if (_keepReading)
            {
                _keepReading = false;
                _serialPort.Close();
                Thread.Sleep(100);    // give it some time
                _readThread.Join();   //block until exits
                //_readThread.Abort();
                //_readThread = null;
            }
        }
