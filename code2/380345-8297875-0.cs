    // ...   
    private void button1_Click(object sender, System.EventArgs e)
    {
        byte[] bytes = new byte[] {
            1 // The byte to send
        };
        serialPort1.Write(bytes, 0, bytes.Length);     
    }
    // ...
