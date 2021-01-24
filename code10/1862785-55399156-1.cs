    while (player.Hp > 0 && enemy.Hp > 0)
    {
    	for (int i = 0; i < p.Moves.Count; i++)
    	{
    		Console.WriteLine(i + " " + p.Moves[i].Name);
    	}                            
    
        if(moveNo >= 0 && moveNo < p.Moves.Count)
        {
            //access move by index
            var move = p.Moves[moveNo]
        }
        else
        {
            // not a valid move
        }
    }
