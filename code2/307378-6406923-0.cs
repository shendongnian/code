            StreamReader menu = new StreamReader("menu.prefs");
            var str = menu.ReadToEnd();
            var items = str.Split(new string[] {"\r\n" } , StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
               Button dynamicbutton = new Button();
               dynamicbutton.Click += new System.EventHandler(menuItem_Click);
               dynamicbutton.Text = item;
               dynamicbutton.Visible = true;
               dynamicbutton.Location = new Point(4+repetition*307, 4);
               dynamicbutton.Height = 44;
               dynamicbutton.Width = 203;
               dynamicbutton.BackColor = Color.FromArgb(40,40,40);
               dynamicbutton.ForeColor = Color.White;
               dynamicbutton.Font = new Font("Lucida Console", 16);
               dynamicbutton.Show();
               menuPanel.Controls.Add(dynamicbutton);
               repetition++;
            }
