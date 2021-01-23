           public void DoFunction()
           { 
             .....
             .....
             pictureBox1.Invalidate() /* here automatic call to pictureBox1_Paint(object sender, PaintEventArgs e) */
             . . . . 
             } 
