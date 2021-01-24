     public Brush Colour(int i)
            {
                Brush snakeColour;
                i %= 6;
                switch (i)
                {
                    case 0:
                        snakeColour = Brushes.HotPink;
                        break;
    
                    case 1:
                        snakeColour = Brushes.Orange;
                        break;
    
                    case 2:
                        snakeColour = Brushes.PeachPuff;
                        break;
    
                    default:
                        snakeColour = Brushes.White;
                        break;
    
                }
                return snakeColour;
            }
