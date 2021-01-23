    class Program
    {
        static string left;
        static string right;
        static void Main(string[] args)
        {
            int size = 20;
            int sizem = size*2 + 1;
            Map m = new Map(new int[sizem,sizem]);
            AddFormationAlt(m, 1, size, size, size-1, 2);
            var l = left;
            var r = right;
        }
        private class Map
        {
            public int[,] Data { get; set; }
            public Map(int[,] data)
            {
                Data = data;
            }
            public string Print()
            {
                StringBuilder sb = new StringBuilder();
                for (int x = 0; x < Data.GetLength(0); x++)
                {
                    for (int y = 0; y < Data.GetLength(1); y++)
                        sb.Append(Data[y, x] == 0 ? " " : Data[y,x] == 1 ? "." : "#");
                    sb.AppendLine();
                }
                return sb.ToString();
            }
        }
        static void AddFormationAlt(Map _map, int tile, int x, int y, int length, int endTile)
        {
            // You may need to change the cloning method when you change the tiles from ints
            Map m1 = new Map((int[,])_map.Data.Clone());
            Map m2 = new Map((int[,])_map.Data.Clone());
            // Contains the left and right half of the Map you want, you need to join these together.
            Map aleft = AddFormationAlt(m1, true, tile, x, y, length, endTile);
            Map aright = AddFormationAlt(m2, false, tile, x, y + 1, length, endTile);
            left = aleft.Print();
            right = aright.Print();
        }
        static Map AddFormationAlt(Map _map, bool up, int tile, int x, int y, int length, int endTile)
        {
            if (x >= 0 && x < _map.Data.GetLength(0) && y >= 0 && y < _map.Data.GetLength(1))
            {
                if (_map.Data[y, x] != tile)
                {
                    if (length > 0)
                    {
                        _map.Data[y, x] = tile;
                        int newlength = length - 1;
                        // Either go 'up' or 'down'
                        if(up)
                            AddFormationAlt(_map, true, tile, x, y - 1, newlength, endTile); // ^
                        else
                            AddFormationAlt(_map, false, tile, x, y + 1, newlength, endTile); // v
                        AddFormationAlt(_map, up, tile, x - 1, y, newlength, endTile); // <-
                        AddFormationAlt(_map, up, tile, x + 1, y, newlength, endTile); // ->
                    }
                    else
                        _map.Data[y, x] = endTile;
                }
            }
            return _map;
        }
    }
