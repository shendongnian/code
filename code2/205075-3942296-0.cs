    public delegate void textBoxWriteDelegate(string msg);
    
    private void textBoxWrite(string sMess) {
      textBox.AppendText(sMess);
    }
