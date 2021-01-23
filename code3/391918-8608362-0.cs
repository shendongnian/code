    private void button1_Click(object sender, EventArgs e) 
    {     
         int top = 50;
         int left = 100;
    
         for (int i = 0; i < 10; i++)     
         {         
              Button button = new Button();   
              button.Left = 100;
              button.Top = top;
              this.Controls.Add(button);      
              top += button.Height + 2;
         }
    } 
