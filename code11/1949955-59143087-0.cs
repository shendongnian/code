      private async void kontrol()
      {
       pictureBox1.Visible = false;
       pictureBox2.Visible=false;
       await Task.Delay(1000);
       pictureBox1.Visible = true;
       pictureBox2.Visible=true;
     }
