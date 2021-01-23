	int x = 4;
	int y = 4;
	foreach(PhysicianData pd in listPhysicians)
	{
	   x = 4;
	   y = panPhysicians.Controls.Count * 30;
	   RadioButton rb = new RadioButton();
	   rb.CheckedChanged += new System.EventHandler(rbPhysician_CheckedChanged);
	   rb.Text = pd.name;
	   rb.Visible = true;
	   rb.Location = new Point(x, y);
	   rb.Height = 40;
	   rb.Width = 200;
	   rb.BackColor = SystemColors.Control;
	   rb.ForeColor = Color.Black;
	   rb.Font = new Font("Microsoft Sans Serif", 10);
	   rb.Show();
	   rb.Name = "rb" + panPhysicians.Controls.Count;
	   panPhysicians.Controls.Add(rb);
	}
