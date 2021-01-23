    public partial class Form1: Form {
        SerialPort serialInput;
        // I want to create a new thread that will pass the parameter serialInput into the method
        // SMSListener on another class and run the method contionously on the background.
        SMS sms = new SMS();
        Thread t = new Thread(sms.SMSListenerUntyped);
        t.Start(serialInput);
    }
    class SMS
    {
        public void SMSListenerUntyped(object serial1) {
            if (serial1 is SerialPort) //Check if the parameter is correctly typed.
                 this.SMSListener(serial1 as SerialPort);
            else
               throw new ArgumentException();
        }
        public void SMSListener(SerialPort serial1)
        {
            serial1.DataReceived += port_DataRecieved;
        }
        private void port_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            // Other code.
        }
