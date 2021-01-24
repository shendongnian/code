    private void button2_Click(object sender, EventArgs e)
    {
        var player = players[CurrentPlayer];
        //rnd.Next() upper bound is **exclusive**.
        // Also, two rolls from 1-6 produce a different distribution
        //  than one roll from 1-12.
        int Dice = rnd.Next(1, 7) + rnd.Next(1, 7);
        label14.Text = Dice.ToString(); 
    
        player.Position += Dice;
    
        //community chest at board positions 2, 17, and 33.
        if (player.Position == 2 || player.Position == 17 || player.Position == 33) 
        {
            label14.Text = "You have landed on a community chest. Please click the chest button.";
        }
    
        CurrentPlayer++;
        if (CurrentPlayer >= players.Length) 
            CurrentPlayer = 0;
    }
