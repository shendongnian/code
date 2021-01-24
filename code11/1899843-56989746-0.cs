    public void readCapsule(SerialPort sp)
    {
            timer1.Enabled = false;
            string headerStart = "";
            string headerEnd = "";
            List<Int32> newCoordinates = new List<Int32>();
            
            headerStart = sp.ReadLine();
            tbRead.AppendText(headerStart + Environment.NewLine);
            
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
            readCapsule(spCapsule);
            timer1.Enabled = true;
        }
