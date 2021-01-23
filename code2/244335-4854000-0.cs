    for (int i = 0; i < 25; i++)
    {
      ....
      var box = new PictureBox();
      pbList.Add(box);
      box.MouseHover += delegate { this.beeShowInfo(box); }
    }
    
    private void beeShowInfo(PictureBox box) 
    {
       lb_beeInfo.Text = "You are hovering over: "+box.Name;
    }
