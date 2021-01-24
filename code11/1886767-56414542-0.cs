     private void Form1_Load(object sender, EventArgs e)
     {
         this.FormClosing += new FormClosingEventHandler(FormClosingEvent);       
     }
    
     private void FormClosingEvent(object sender, FormClosingEventArgs e)
     {
         form2 f2 = new form2();
         f2.ShowDialog();
    
     }
