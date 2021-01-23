    public class Map
    {
         public MapPoint[,] mapPoints; 
         public Player player;
         //some kind of class that represents a specific 512x512 point (mapPoint)
         //mapPoints also includes the sprite that is going to be drawn and objects
         //that the player can interact with at that place (like the door)
         //the player object includes reference to where in the world it is placed
         
         int sizeX; //number of 512x512 points that is the map
         int sizeY;
         int rangeStartX;
         int rangeStartY;
         public Map(ContentManager theContentManager, int x, int y)
         {
            sizeX= x;
            sizeY= y;
            mapPoints = new MapPoint[sizeX, sizeY];
            player = new Player(mapPoints[10,10]);  //crate a player who knows where he is
            //ad code for generating/creating map...
        }
        public void Update()
        {
           //in the update method you do a lot of things like movement and so
           
           //set what part of the map the game should draw if the game for example
           //can show 9x9 512points at a single time
           rangeStartX = player.PositionX - 4;
           rangeStartY = player.PositionY - 4;
           if(rangeStartX < 0){rangeStartX = 0;}
           if(rangeStartY < 0){rangeStartY = 0;}
        }
        public void Draw()
        {
            int x = rangeStartX;
            int y = rangeStartY;
            for(; x <= (rangeStartX +4); x++)
            {
                for(; y <= (rangeStartY +4); y++)
                {
                     mapPoints[x, y].draw() //need where to draw it as in parameter
                }
                int y = rangeStartY;
            }
        }
    }
