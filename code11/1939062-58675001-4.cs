    int x = 0;
    int y = 0;
    int delta = 10;
    for ( int i = 0; i < contacts.Count; i++ )
    {
      // Create picture box
      var picture = new PictureBox();
      picture.Image = Image.FromFile(contacts[i].pathImage);
      picture.Location = new Point(x, y);
      picture.Size = new Size(picture.Image.Width, picture.Image.Height);
      int dx = picture.Width + delta;
      // Create name label
      var labelName = new Label();
      labelName.AutoSize = true;
      labelName.Location = new Point(x + dx, y);
      labelName.Font = new Font(labelName.Font, FontStyle.Bold);
      labelName.Text = contacts[i].Prenom + " " + contacts[i].Nom;
      // Create mail label
      var labelMail = new Label();
      labelMail.AutoSize = true;
      labelMail.Location = new Point(x + dx, y + labelName.Height);
      labelMail.Text = contacts[i].mail;
      // Create phone label
      var labelPhone = new Label();
      labelPhone.AutoSize = true;
      labelPhone.Location = new Point(x + dx, y + labelName.Height + labelMail.Height);
      labelPhone.Text = contacts[i].tel;
      // Add controls
      panel.Controls.Add(picture);
      panel.Controls.Add(labelName);
      panel.Controls.Add(labelMail);
      panel.Controls.Add(labelPhone);
      // Iterate
      int dy1 = labelName.Height + labelMail.Height + labelPhone.Height;
      int dy2 = picture.Height;
      y += Math.Max(dy1, dy2) + delta;
    }
