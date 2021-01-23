    var interval = 3000; // ms
    var timer = new System.Timers.Timer(interval);
    timer.Elapsed += (o,e) => 
        {
            timer.Enabled = false;
            if (testSerial.IsOpen)
                testSerial.Close();  // may not be necessary with Dispose?
            testSerial.Dispose();
            timer.Dispose();
        }
    
    timer.Enabled = true;
