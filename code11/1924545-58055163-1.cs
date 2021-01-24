     private void button1_Click(object sender, EventArgs e) {
         var wasVisible = panel1.Visible;
         panel1.Visible = !wasVisible;
     }
     private void button2_Click(object sender, EventArgs e) {
         panel2.BringToFront();
     }
     private void button3_Click(object sender, EventArgs e) {
         panel3.BringToFront();
     }
