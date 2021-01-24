    int i = chosenHoleInt;
            while(Board.Holes[chosenHoleInt].Stones != 0)
            {
                if (i >= Board.Holes.Length)
                {
                    i = 0;
                    continue;
                }
                Board.Holes[chosenHoleInt].Stones--;
                Board.Holes[i].Stones++;
                i++;
            }
