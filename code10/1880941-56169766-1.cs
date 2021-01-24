    public class LevelViewModel
    {
        public ObservableCollection<BlockViewModel> Blocks { get; }
    }
        public class BlockViewModel
    {
        public LevelBlock _model { get; set; }
        public BlockViewModel(LevelBlock model)
        {
            _model = model;
        }
        public int X
        {
            get { return _model.Position; }
        }
        public int Y
        {
            get { return _model.Position; }
        }
        public int Height
        {
            get { return _model.GapHeight; }
        }
        public int Width
        {
            get { return _model.GapHeight; }
        }
    }
    
