    void MyClosingEvent(object o, FormClosingEventArgs args)
    {
    }
    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Form1 form1 = new Form1();
        form1.FormClosing += new FormClosingEventHandler(MyClosingEvent);
        //Or if you have C# 2 or higher: 
        //form1.FormClosing += MyClosingEvent;
