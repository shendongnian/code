    public bool CheckForBingo(bool[,] boardState)
            {
                bool haveWeWon = false;
    
                //check horizotal
                for (int i = 0; i < 5; i++)
                {
                    haveWeWon = true;
    
                    for (int y = 0; y < 5; y++)
                    {
                        if (!boardState[i, y])
                        {
                            haveWeWon = false;
                            break;
                        }
                    }
    
                    if(haveWeWon)
                    {
                        return haveWeWon;
                    }
                }
    
                if (!haveWeWon)
                {
                    //check vertical
                    for (int i = 0; i < 5; i++)
                    {
                        haveWeWon = true;
    
                        for (int y = 0; y < 5; y++)
                        {
                            if (boardState[y, i])
                            {
                                haveWeWon = false;
                                break;
                            }
                        }
    
                        if (haveWeWon)
                        {
                            return haveWeWon;
                        }
                    }
                }
    
                //check the middle - if false dont bother checking diagonal
                if (boardState[2, 2])
                {
                    if (!haveWeWon)
                    {
                        //check top left diagonal 
                        for (int i = 0; i < 5; i++)
                        {
                            haveWeWon = true;
    
                            if (!boardState[i, i])
                            {
                                haveWeWon = false;
                                break;
                            }
                        }
    
                        if (haveWeWon)
                        {
                            return haveWeWon;
                        }
                    }
    
                    if (!haveWeWon)
                    {
                        //check top right diagonal 
                        for (int i = 4; i >= 0; i--)
                        {
                            haveWeWon = true;
    
                            if (!boardState[i, i])
                            {
                                haveWeWon = false;
                                break;
                            }
                        }
    
                        if (haveWeWon)
                        {
                            return haveWeWon;
                        }
                    }
                }
                return false;
            }
