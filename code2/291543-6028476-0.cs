        public void OnButtonClick(object sender, EventArgs e)
        {
            SerialPort serialInput = this.SerialInput;
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                SmsListener listener = new SmsListener(serialInput);
            });
        }
