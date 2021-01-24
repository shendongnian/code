    class MainWindowVm
    {
        public MainWindowVm()
        {
            Game = new GameVm(20, 20);
        }
        public GameVm Game { get; }
    }
    class GameVm : ViewModel
    {
        public GameVm(int width, int height)
        {
            Width = width;
            Height = height;
            Entities = new ObservableCollection<GameEntity>();
            Entities.Add(new SnakeHead() { X = 20, Y = 20 });
            Entities.Add(new SnakeBody() { X = 30, Y = 20 });
            Entities.Add(new SnakeBody() { X = 40, Y = 20 });
            Entities.Add(new SnakeTail() { X = 40, Y = 30 });
            
            Entities.Add(new Food() { X = 0, Y = 0 });
            Entities.Add(new Food() { X = 60, Y = 20 });
            Entities.Add(new Food() { X = 50, Y = 50 });
            Entities.Add(new Food() { X = 10, Y = 80 });
        }
        
        public ObservableCollection<GameEntity> Entities { get; }
        private int _width;
        public int Width
        {
            get => _width;
            set => SetValue(ref _width, value);
        }
        private int _height;
        public int Height
        {
            get => _height;
            set => SetValue(ref _height, value);
        }
        }
    abstract class GameEntity : ViewModel
    {
        private int _x;
        public int X
        {
            get => _x;
            set => SetValue(ref _x, value);
        }
        private int _y;
        public int Y
        {
            get => _y;
            set => SetValue(ref _y, value);
        }
    }
    abstract class SnakeSegment : GameEntity { }
    class SnakeBody : SnakeSegment { }
    class SnakeHead : SnakeSegment { }
    class SnakeTail : SnakeSegment { }
    class Food : GameEntity { }
