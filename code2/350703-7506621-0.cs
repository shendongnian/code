     private void onPaint(object sender, PaintEventArgs e) {
           Timer1.Enabled = false;
         //350 lines of (adjusted)code go here
         If (ElapsedPercent<1)
         {
             Timer1.Enabled=True;
         }
         else
         {
             // you may need to perform the last draw setting the ElapsedPercent 
             // to 1. This is because it is very unlikely that your 
             // last call will happen at the very last millisecond
         }
     }
