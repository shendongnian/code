        if (IsPostBack)
        {
            PlaceHolder p = new PlaceHolder();
            PlaceHolder1.Controls.Add(p);
            for (int i = 0; i < 2; i++)
            {
                Button newBtn = new Button();
                newBtn.CommandName = i.ToString();
                newBtn.Text = i.ToString();
                newBtn.Command += Clicked;
                btnsDic.Add(i, newBtn);
                p.Controls.Add(newBtn); 
            }
        }
