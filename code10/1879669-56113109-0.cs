    public int count = 0;
    private void Timer1_Tick(object sender, EventArgs e)
    {
         this.count++;
         if(this.count == 10)
         {
                 if (this.BackColor == Color.Red)
                 {
                        this.BackColor = Color.White;
                 }
                 else
                 {
                        this.BackColor = Color.Red;
                 }
         }
         else {
               if (this.BackColor == Color.LightGreen)
               {
                     this.BackColor = Color.White;
               }
               else
               {
                     this.BackColor = Color.LightGreen;
               }
               this.count = 0;
         }
    }
