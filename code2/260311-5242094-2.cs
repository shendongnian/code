    public class MainViewModel
    {
        public IEnumerable<SquareViewModel> Squares { get; set; }
    
        public MainViewModel()
        {
            var squares = new List<SquareViewModel>();
            squares.Add(new SquareViewModel(15, 15,100,100, Brushes.CadetBlue, "Square One"));
            squares.Add(new SquareViewModel(75,125, 80, 80, Brushes.Indigo, "Square Two"));
            Squares = squares;
        }
    }
    public class SquareViewModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Brush Color { get; set; }
        public string Name { get; set; }
    
        public SquareViewModel(int x, int y, int width, int height, Brush color, string name)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color;
            Name = name;
        }
    }
