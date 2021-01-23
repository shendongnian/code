     foreach(Control gb in this.Controls)
     {
           if(gb is GroupBox)
           {
              foreach(Control tb in gb.Controls)
              {
                 if(tb is TextBox)
                 {
                     //here is where you access all the textboxs.
                 }
              }
           }
     }
