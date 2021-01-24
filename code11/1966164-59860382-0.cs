    private int movesLeft = 6;
    private void Gameplay_KeyDown(object sender, KeyEventArgs e)
    {
        if(movesLeft > 0)
        {
            int x = placeholder1.Location.X;
            int y = placeholder1.Location.Y;
            if (e.KeyCode == Keys.Right) x += 64;
            else if (e.KeyCode == Keys.Left) x -= 64;
            else if (e.KeyCode == Keys.Down) y += 64;
            else if (e.KeyCode == Keys.Up) y -= 64;
            placeholder1.Location = new Point(x, y);
            movesLeft--;
            Console.WriteLine($"{movesLeft} moves left!");
        }
    }
