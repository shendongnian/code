    private void Timer_Tick(object sender, EventArgs e)
    {
        const int timeout = 1500;
        if ((DateTime.Now - _lastBarCodeCharReadTime).Milliseconds < timeout)
            return;
    
        _timer.Stop();
        // raise Changed event with barcode = textBox1.Text            
    }
