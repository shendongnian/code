    private int _nextLevel = 100;
    void Level()
    {
        if (count > _nextLevel && count < 4000)
        {
            _nextLevel += 100;
            level = level + 1;
            MessageBox.Show("Congratulations, you ranked up to level " + level.ToString(), "Cookie Clicker 2.0");
            label2.Text = "Level: " + level.ToString();
        }
        else if (count >= 4000)
        {
            MessageBox.Show("Congratulations! We have not fixed any more in this game.", "Cookie Clicker 2.0", MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }
