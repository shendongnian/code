    public enum MapStatus
    {
        Empty = 0,
        Ship = 1,
        HitShip = 2,
        HitWater = 3
    }
    public class Map
    {
        MapStatus[,] mapTiles;
        public Map(int[,] mapInt = null)
        {
            if (mapInt == null) // if there's no map in parameters we'll set a default map..
            {
                mapInt = new int[,]
                {
                    { 0, 0, 0, 0, 0 },
                    { 0, 1, 1, 1, 1 },  // in this row there's a ship
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 },
                };
            }
            // Initialize empty map
            mapTiles = new MapStatus[mapInt.GetLength(0), mapInt.GetLength(1)];
            // copy numbers into our map
            for (int i = 0; i < mapTiles.GetLength(0); i++)
            {
                for (int j = 0; j < mapTiles.GetLength(1); j++)
                {
                    mapTiles[i, j] = (MapStatus)mapInt[i, j];
                }
            }
        }
        /// <summary>
        /// "Graphics-Engine" which enables us to print our map.
        /// </summary>
        public void PrintMap()
        {
            Console.Clear();
            Console.Write("        ");
            for (int j = 0; j < mapTiles.GetLength(1); j++)
            {
                Console.Write(j.ToString().PadLeft(8));
            }
            Console.WriteLine();
            for (int i = 0; i < mapTiles.GetLength(0); i++)
            {
                Console.Write(i.ToString().PadLeft(8));
                for (int j = 0; j < mapTiles.GetLength(1); j++)
                {
                    Console.Write(mapTiles[i, j].ToString().PadLeft(8) + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Check if there are ships left. Have a look at Linq ;)
        /// </summary>
        public bool StillAlive()
        {
            return mapTiles.Cast<MapStatus>().Any(a => a == MapStatus.Ship);
        }
        public bool Shoot(int x, int y)
        {
            // Error-Checking if the values are valid..
            if (x < 0 || x >= mapTiles.GetLength(0))
                throw new ArgumentOutOfRangeException(string.Format("X-coordinate ({0}) is wrong (min: {1}, max: {2})!", x, 0, mapTiles.GetLength(0)));
            if (y < 0 || y >= mapTiles.GetLength(1))
                throw new ArgumentOutOfRangeException(string.Format("Y-coordinate ({0}) is wrong (min: {1}, max: {2})!", y, 0, mapTiles.GetLength(1)));
                
            // Check if we shot here before..
            if (mapTiles[x, y] == MapStatus.HitShip || mapTiles[x, y] == MapStatus.HitWater)
                throw new ArgumentException(string.Format("You did already shoot the coordinates {0}/{1}", x, y));
            // Shoot
            if (mapTiles[x, y] == MapStatus.Empty)
            {
                mapTiles[x, y] = MapStatus.HitWater; // Change value
                return false; // return the info that we didn't hit anything
            }
            else
            {
                mapTiles[x, y] = MapStatus.HitShip;
                return true;
            }
        }
    }
    public static void Main(string[] args)
    {
        Map m = new Map(); // Initialize without map.
        int x;
        int y;
        while (m.StillAlive()) // Loop untill all ships are sunk
        {
            m.PrintMap();
            Console.Write("Enter X: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Y: ");
            y = Convert.ToInt32(Console.ReadLine());
            try
            {
                bool hit = m.Shoot(x, y);
                m.PrintMap();
                if (hit)
                    Console.WriteLine("We hit a ship!");
                else
                    Console.WriteLine("We hit only water!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            Console.WriteLine("(Press Enter to continue)");
            Console.ReadLine();
        }
        Console.WriteLine("We won!");
        Console.ReadLine();
    }
