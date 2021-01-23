    public void MoveBubble(Bubble b, double radians)
    {
        if (b.stop == false)
        {
            {
               //Move bubble 'up'
                Y = (float)(speed * Math.Cos(radians));
                X = (float)(speed * Math.Sin(radians));
            }
    
            b.bubblePosX += X;
    
            //Problem area
            if(b.bubblePosY <= 0 || b.bubblePosY >= 350)
                b.bubblePosY -= Y;
            else
                b.bubblePosY += Y;
        }
    }
