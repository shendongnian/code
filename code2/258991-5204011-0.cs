    foreach (int i in Enumerable.Range(0, 10))
    {
        foreach (int j in Enumerable.Range(0, 10))
        {
            Button b = new Button();
            b.Size = new System.Drawing.Size(20, 20);
            b.Location = new Point(i * 20, j * 20);
            b.Click += new EventHandler(anyButton_Click); // <-- all wired to the same handler
            this.Controls.Add(b);
        }
    }
