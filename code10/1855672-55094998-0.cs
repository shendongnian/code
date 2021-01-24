    private Button[,] btns = new Button[3,3] {
                               {button1,button2,button3},
                               {buttonQ,buttonW,buttonE},
                               {buttonA,buttonS,buttonD}};
    private int x=0, y=0;
    private void buttonLeft_Click(object sender, EventArgs e)
    {
        if(y>0)
        {
            y--;
            btns[x,y].Focus();
        }
    }
   
    private void buttonRight_Click(object sender, EventArgs e)
    {
        if(y<3)
        {
            y++;
            btns[x,y].Focus();
        }
    }
  
    private void buttonUp_Click(object sender, EventArgs e)
    {
        if(x>0)
        {
            x--;
            btns[x,y].Focus();
        }
    }
  
    private void buttonDown_Click(object sender, EventArgs e)
    {
        if(x<3)
        {
            x++;
            btns[x,y].Focus();
        }
    }
