    class MapInfo
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Terrain { get; set; }
        public bool alreadyVisited { get; set; }
    
        // Anything else you want to record
        // … … 
    }
    class PlayerInfo
    {
        public int currentPosX { get; set; }
        public int currentPosY { get; set; }
        public MapInfo currentMapInfo { get; set; }
        public void getCurrentMapInfo()
        {
           currentMapInfo = KnownPlaces.GetMapInfo(currentPosX, currentPosY);
        }
    }
    public class KnownPlaces 
    {
        public static List<MapInfo> AllKnownPlaces = new List<MapInfo>();
        public static MapInfo GetMapInfo(int posX, int posY)
        {
          MapInfo place = KnownPlaces.AllKnownPlaces.FirstOrDefault(n => n.PosX == posX && n.PosY == posY);
          return place;
        }
        Public static void CreateNewMapInfo(int posX, int posY, //… other stuff you want to record)
        {
           MapInfo newMapInfo = new MapInfo();
           newMapInfo.PosX = posX;
           newMapInfo.PosY = posY;
           // Anything else that you want to record.
           KnownPlaces.AllKnownPlaces.Add(newMapInfo);
        }   
    }
