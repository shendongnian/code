        for (int i = 0; i< 8; i++)    
    {
        for (int j = 0; j < 8; j++)
          {
            Button BtnNew = new Button;
            BtnNew.Height = 80;
            BtnNew.Width = 80;
            BtnNew.Location = new Point(80*i, 80*j);
            this.Controls.Add(BtnNew);
           }
    }
