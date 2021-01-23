    this.SuspendLayout();
                Random r=new Random(DateTime.Now.Millisecond);
                for (int i = 0; i < 3; i++)
                {
    
                    userControl11[i] = new UserControl1();
                    this.userControl11[i].formColor = Color.FromArgb(r.Next(255),r.Next(255),r.Next(255));
                    this.userControl11[i].Location = new System.Drawing.Point(133 , 133*(i+1));
                    this.userControl11[i].Name = "userControl11";
                    this.userControl11[i].Size = new System.Drawing.Size(278, 133);
                    this.userControl11[i].TabIndex = 0;
                    this.Controls.Add(this.userControl11[i]);
                }
                ;
