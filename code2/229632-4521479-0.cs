    public class Seat
    {
        public string ID { get; set; }
        public bool Occupied { get; set; }
    }
    int rows = 10, cols = 10;
    Seat[,] seats = new Seat[rows,cols];
    for (int i = 0; i < rows; ++i )
    {
        for (int j = 0; j < cols; ++j)
        {
             seats[i,j] = new Seat { ID = "Seat" + (i*cols + j), Occupied = false };
        }
    }
    foreach (var seat in seats)
    {
        Console.WriteLine( "{0} is{1} occupied", seat.ID, seat.Occupied ? "" : " not" );
    }
