c#
      private int  clickCounter = 0;
      private void btnFillo_Click (object sender, EventArgs e) {
         btnFillo.Text = "text";
         if (clickCounter >= 1) {
         // do something
         clickCounter = 0;
         }
         else  clickCounter += 1;
      }
or simply : 
c#
      private bool  isClicked = false;
      private void btnFillo_Click (object sender, EventArgs e) {
         btnFillo.Text = "text";
         if (isClicked) {
         // do something
            isClicked = false;
         } else isClicked = true;
      }
