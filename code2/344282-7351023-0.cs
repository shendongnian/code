    // Given:
    class Direction
    {
         public Direction(string dir, int min, int max)
         {
             MinHeading = min;
             MaxHeading = max;
             Direction = dir;
         }
         public int MinHeading { get; private set; }
         public int MaxHeading { get; private set; }
         public string Direction { get; private set; }
    }
    // And a collection:
    var directions = new List<Direction>
                   {
                       new Direction("N",0,0),
                       new Direction("NNE",1,44),
                       ...
                   }
    // You can find a direction given
    int compassHeading = 93;
    string direction = directions
                       .First(d => compassHeading >= d.MinHeading && compassHeading <= d.MaxHeading)
                       .Select(d => d.Direction);
