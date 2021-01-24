    for(int i = 0; i < contacts.Count; i++)
        {
          YourUserControl u1 = new YourUserControl(pass the person object);
          Panel1.Controls.Add(u1);
          u1.Location = new Point(0, i * 50);
        }
