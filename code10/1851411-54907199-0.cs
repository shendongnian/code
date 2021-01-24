    private void Form_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        switch (e.KeyCode) {
             case Keys.W: { 
                 label1.Top -= 1;
                 break;
             }
             case Keys.A: { //do stuff on A button }
             case Keys.S: { //do stuff on S button }
             case Keys.D: { //do stuff on D button }
             default: { break; }
        }
    }
