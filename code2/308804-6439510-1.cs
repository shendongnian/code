    for (int i = 0; i < 100; i++)
    {
        var index = i; // YOU NEED TO DO THIS
        buttons[i] = new Button();
        buttons[i].SetBounds(i % 10 * 50, i / 10 * 50, 50, 50);
        buttons[i].Click += (sender, e) => myClick(index); // THIS SOLVES THE PROBLEM
        this.Controls.Add(buttons[i]);
    }
