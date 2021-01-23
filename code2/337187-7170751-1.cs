    List<Label> labels = new List<Label>();
   
    for (int i = 0; i < 30; i++) {
        var temp = new Label();
        
        temp.Location = new Point(r.Next(ClientRectangle.Right -10),
                                           r.Next(ClientRectangle.Bottom - 10));
        temp.Text = "o";
        temp.Click += new EventHandler(Form1_Load);
        temp.BackColor = System.Drawing.Color.White;
        this.Controls.Add(temp);
        temp.Show();
        labels.Add(temp) 
    }
