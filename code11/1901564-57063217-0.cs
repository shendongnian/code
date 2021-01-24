    if (player1.Turn > 2)
            {
                foreach (int[] row in player1.Sequence)
                {
                    foreach (int[] row2 in player1.GetSequence)
                    {
                        foreach (int[] col in player1.TrackCol)
                        {
                            if (Enumerable.SequenceEqual(row, row2))
                            {
                                winner = true;
                            }
                            else if(Enumerable.SequenceEqual(col, row2))
                            {
                                winner = true; 
                            }
                        }
                    }
                }
            }
