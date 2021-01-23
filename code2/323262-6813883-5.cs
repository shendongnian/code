    public class Map
    {
         public MapPoint[,] mapPoints;       //the map
         public Player player;               //the player/user object
         public Vector2 DrawHeroPosition;    
         //where at the screen the player is going to be drawn
         public Vector2 RangeStart;          
         //what part of the map who is going to be drawn
         public int SizeX;     //number of mapPoints the screen can contain at one time 
         public int SizeY;     //number of mapPoints the screen can contain at one time 
         //MapPoint represents a specific 512x512 point (mapPoint) its position at
         //the map but also includes the sprite that is going to be drawn and objects
         //that the player can interact with at that place (like the door)
         //the player object includes reference to where in the world it is place
         public Map(ContentManager theContentManager, int x, int y)
         {
            MapSizeX = x;
            MapSizeY = y;
            int ScreenSizeX = 9;
            int ScreenSizeY = 9;
            mapPoints = new MapPoint[MapSizeX , MapSizeY];
            //ad code for generating/creating map...
            //important that you store the MapPoints position inside each mapPoint
            player = new Player(mapPoints[0,0]);  //crate a player who knows where he is
        }
        public void Update()
        {
           //in the update method you do a lot of things like movement and so
           //set what part of the map the game should draw if the game for example
           //can show 9x9 512points at a single time
           //give range value from the players position
            RangeStart.X = player.PositionX;
            //test if the maps position is in the left corner of the map
            //if it is draw the map from the start..(RangeStart.X = 0)
            if (player.PositionX - (ScreenSizeX / 2) < 0) { RangeStart.X = 0; }
            //if not draw the hero in the mitle of the screen
            else
            {
                RangeStart.X = player.PositionX - (ScreenSizeX / 2);
            }
            //if the hero is in the right corer, fix his position
            while (RangeStart.X + ScreenSizeX > MapSizeX)
            {
                RangeStart.X--;
            }
            //the same thing for the Y axle
            RangeStart.Y = player.PositionY;
            if (player.PositionY - (ScreenSizeY / 2) < 0) { RangeStart.Y = 0; }
            else
            {
                RangeStart.Y = player.PositionY - (ScreenSizeY / 2);
            }
            while (RangeStart.Y + ScreenSizeY > MapSizeY)
            {
                RangeStart.Y--;
            }
            //time to set the position of the hero...
            //he works like the opposite of the range, if you move what part of the map
            //you draw you dont change the heros draw position, if you dont move the range
            //you have to move the hero to create the illusion of "moment"
            //if you are in the left part you have to move the heros draw position..
            if (player.PositionX - (ScreenSizeX / 2) < 0) 
            { DrawHeroPosition.X = player.PositionX; }
            
            //if you are in the right part
            else if (player.PositionX+1 > MapSizeX - (ScreenSizeX / 2))
            {
                DrawHeroPosition.X = player.PositionX - (MapSizeX - ScreenSizeX);
            }
            //if you aint in a corner, just place the hero in the middle of the map
            else
            {
                DrawHeroPosition.X = (ScreenSizeX / 2);
            }
            //the same thing for Y
            if (player.PositionY - (ScreenSizeY / 2) < 0) 
            { DrawHeroPosition.Y = player.PositionY; }
            else if (player.PositionY+1 > MapSizeY - (ScreenSizeY / 2))
            {
                DrawHeroPosition.Y = player.PositionY - (MapSizeY - ScreenSizeY);
            }
            else
            {
                DrawHeroPosition.Y = (ScreenSizeY / 2);
            }
        }
        public void Draw()
        {
            int x = (int)RangeStart.X;
            int y = (int)RangeStart.Y;
           
            for(int counterX = 0; x < ((MapSizeX)); x++, counterX++)
            {
                for (int counterY = 0; y < (MapSizeY); y++, counterY++)
                {
                   if (mapPoints[x, y] != null)
                   {
                     mapPoints[x, y].Draw(spriteBatch, mapPoints[counterX,counterY].positonInMatrix);
                     //mapPoints[counterX,counterY] = where to draw
                     //mapPoints[x, y] = what to draw
                   }
                }
                y = (int)RangeStart.Y;
            }
        }
    }
